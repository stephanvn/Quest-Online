using UnityEngine;
using System.Collections;

public class BattleStateManager : MonoBehaviour {
    public enum BattleStates
    {
        INIT,
        PLAYERCHOICE,
        ENEMYCHOICE,
        PROCESSBATTLE,
        LOSE,
        WIN
    }
    private BattleStates currentState = BattleStates.INIT;

	void Start () {
        currentState = BattleStates.INIT;
	}
	
	void Update () {
	    switch (currentState)
        {
            case (BattleStates.INIT):
                Debug.Log("Initializing battle"); break;

            case (BattleStates.PLAYERCHOICE):
                Debug.Log("Player is choosing an option"); break;

            case (BattleStates.ENEMYCHOICE):
                Debug.Log("Enemy is choosing an option"); break;

            case (BattleStates.PROCESSBATTLE):
                Debug.Log("Battle is being played out"); break;

            case (BattleStates.WIN):
                Debug.Log("Player victory"); break;

            case (BattleStates.LOSE):
                Debug.Log("Player defeat"); break;
        }
	}
}
