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
}
