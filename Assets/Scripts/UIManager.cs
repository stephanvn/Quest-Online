using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text username;
	public Text treasure_found;
	public Text treasure_remaining;
	public string playerName;
	public int found;
	public int left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//hp.text = "HP: " + playerHP;
		username.text = playerName;
		//level.text = "Level: " + playerLvl;
	}
}
