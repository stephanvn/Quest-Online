using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {
    public enum BattleStates
    {
        INIT,
        PLAYERCHOICE,
        ENEMYCHOICE,
        PROCESSBATTLE,
        LOSE,
        WIN
    }
    private BattleStates currentState;
    private bool battle = true;
    private int party = 1;
    private List<Monster> enemies = new List<Monster>();

    void Start()
    {
        currentState = BattleStates.INIT;
        Debug.Log(currentState);
        enemies.Add(new Slime());
        enemies.Add(new Slime());
        enemies.Add(new Slime());
        currentState = BattleStates.PLAYERCHOICE;
        Debug.Log(currentState);
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
        foreach (Monster e in enemies)
        {

        }
    }

    private void ProcessBattle()
    {
        //Animation logic will go here
    }

    private void CheckBattleStatus()
    {
        if (!PlayersAreAlive())
        {
            Debug.Log("All players are dead");
        }
        else
        {

        }
    }

    public bool PlayersAreAlive()
    {
        return true;
    }
}
