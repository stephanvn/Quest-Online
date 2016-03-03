﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour {

    public string warpTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D( Collision2D col )
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(warpTarget);
        }
    }
}
