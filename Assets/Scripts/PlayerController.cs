﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    bool gameFinished = false;
    int collected = 0;
    int total = 16;
    string winString = " won the game!";
    int winID;
    int runonce = 0;    

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PhotonView pv = GetComponent<PhotonView>();

        if (GetComponent<PhotonView>().isMine)
        {
            GameObject.Find("Username").GetComponent<Text>().text = "P: " + pv.viewID;
        }
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (other.gameObject.CompareTag("pickUp"))
        {
            Sprite spr = Resources.Load("Sprites/Objects/box2", typeof(Sprite)) as Sprite;
            obj.GetComponent<SpriteRenderer>().sprite = spr;

            collected += 1;
            if (GetComponent<PhotonView>().isMine)
            {
                
                GameObject.Find("found_amount").GetComponent<Text>().text = collected.ToString();
            }
            
            total = Int32.Parse(GameObject.Find("left_amount").GetComponent<Text>().text) - 1;
            GameObject.Find("left_amount").GetComponent<Text>().text = total.ToString();
            other.gameObject.tag = "Untagged";

            if(total == 13)
            {
                gameFinished = true;
                Time.timeScale = 0;
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                int winCount = 0;
                
                foreach (GameObject player in players)
                {
                    PlayerController pc = (PlayerController)player.GetComponent(typeof(PlayerController));
                    if(pc.collected > winCount)
                    {
                        winCount = pc.collected;
                        winID = pc.GetComponent<PhotonView>().viewID;
                    }
                }
            }
        }
    } 

    void OnGUI()
    {
        if (gameFinished)
        {
            if (runonce == 0)
            {                
                winString = GUI.TextField(new Rect(600, 200, 200, 200), "Player " + winID + winString, 100);
                runonce = 1;
            }
            GUI.TextField(new Rect(720, 200, 200, 200), winString, 100);
        }
    }
}
