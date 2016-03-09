using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    List<GameObject> inventory;
    bool showInventory = false;
    Rect dialogueRect = new Rect(700, 150, 500, 500);

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector2.zero;
    private Vector3 syncEndPosition = Vector2.zero;
    Vector3 syncPosition = Vector2.zero;
    Vector3 syncVelocity = Vector2.zero;

    private Vector3 realPosition = Vector3.zero;
    private Quaternion realRotation;
    private Vector3 sendPosition = Vector3.zero;
    private Quaternion sendRotation;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (showInventory)
            {
                showInventory = false;
            }
            else {
                showInventory = true;
            }
        }

        if (GetComponent<NetworkView>().isMine)
        {
            InputMovement();
            InputColorChange();
        }
        else
        {
            SyncedMovement();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            inventory.Add(other.gameObject);
        }
    } 

    void OnGUI()
    {
        if (showInventory)
        {
            GUI.Box(dialogueRect, "Inventory");
            Rect spriteRect = new Rect(720, 200, 100, 100);
            GUIStyle currentStyle = new GUIStyle(GUI.skin.box);

            int counter = 0;
            foreach (GameObject g in inventory)
            {
                SpriteRenderer r = g.GetComponent<SpriteRenderer>();
                currentStyle.normal.background = r.sprite.texture;
                GUI.Box(spriteRect, g.name, currentStyle);
                if (counter == 3)
                {
                    spriteRect.x = 720;
                    spriteRect.y = 350;
                }
                else
                {
                    spriteRect.x += 120;
                }
                counter++;
            }
        }
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (stream.isWriting)
        {//this is your information you will send over the network
            sendPosition = this.transform.position;
            sendRotation = this.transform.rotation;
            stream.Serialize(ref sendPosition);//im pretty sure you have to use ref here, check that
            stream.Serialize(ref sendRotation);//same with the ref here...
        }
        else if (stream.isReading)
        {//this is the information you will recieve over the network
            stream.Serialize(ref realPosition);//Vector3 position
            stream.Serialize(ref realRotation);//Quaternion postion
        }
    }

    void Awake()
    {
        lastSynchronizationTime = Time.time;
    }

    private void InputMovement()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.speed = 0.8f;
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
            anim.speed = .2f;
        }
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }

    private void SyncedMovement()
    {
        //syncTime += Time.deltaTime;

       // rbody.position = Vector2.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);

        transform.position = Vector3.Lerp(this.transform.position, realPosition, Time.deltaTime * 15);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, realRotation, Time.deltaTime * 30);
    }


    private void InputColorChange()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ChangeColorTo(new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    [RPC]
    void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);

        if (GetComponent<NetworkView>().isMine)
            GetComponent<NetworkView>().RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
    }

}
