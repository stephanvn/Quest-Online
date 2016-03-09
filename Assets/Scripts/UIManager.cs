using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text username;
	public Text level;
	public Text hp;
	public string playerName;
	public int playerLvl;
	public int playerHP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hp.text = "HP: " + playerHP;
		username.text = playerName;
		level.text = "Level: " + playerLvl;
	}
}
