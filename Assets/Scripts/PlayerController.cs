using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    List<GameObject> inventory;
    bool showInventory = false;
    Rect dialogueRect = new Rect(700, 150, 500, 500);
    int collected = 0;
    int total = 16;
    public Text scoreCount;
    public Text totalCount;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<GameObject>();
    }

    void Update()
    {       
        if (GetComponent<PhotonView>().isMine)
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
        else
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (other.gameObject.CompareTag("pickUp")) //&& obj.GetComponent(treasureController).checkTaken() == false)
        {
            //other.taken = true;
            Sprite spr = Resources.Load("Sprites/Objects/box2", typeof(Sprite)) as Sprite;
            obj.GetComponent<SpriteRenderer>().sprite = spr;
            //inventory.Add(other.gameObject);
            collected+=1;
            scoreCount.text = collected.ToString();
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
}
