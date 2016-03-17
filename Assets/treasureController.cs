using UnityEngine;
using System.Collections;

public class treasureController : MonoBehaviour {
    public bool taken = false;

	// Use this for initialization
	void Start () {
        taken = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool checkTaken()
    {
        return taken;
    }

    public void Take()
    {
        taken = true;
    }
}
