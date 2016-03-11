using UnityEngine;
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
            GameObject network = GameObject.Find("Network");
            NetworkManager nw = (NetworkManager)network.GetComponent(typeof(NetworkManager));
            nw.Disconnect();
            SceneManager.LoadScene(warpTarget);
        }            
    }
}
