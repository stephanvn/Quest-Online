using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

    private bool battle = true;
    private int party = 1;
    public GameObject battleMenu;
    public GameObject[] enemies = new GameObject[1];

    void Start()
    {
        while (battle)
        {
            PlayerChoice();
            WaitOtherPlayerChoice(); //Placeholder until netcode is implemented
            EnemyChoice(); //Will be server side eventually
            ProcessBattle();
            CheckBattleStatus();
        }
    }
	
    private void PlayerChoice()
    {
        //battleMenu.setVisible(true);
    }

    private void WaitOtherPlayerChoice()
    {
        //Not relevant until netcode is implemented
    }

    private void EnemyChoice()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            //enemies[i].battleChoice = enemies[i].MakeBattleChoice();
        }
    }

    private void ProcessBattle()
    {

    }

    private void CheckBattleStatus()
    {
        if (!PlayersAreAlive())
        {
            Debug.Log("All players are dead");
        }
    }

    public bool PlayersAreAlive()
    {
        return true;
    }
}
