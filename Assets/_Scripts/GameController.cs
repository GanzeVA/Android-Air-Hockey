using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static int player1Goals;
    private static int player2Goals;
    public int maxGoals;


	void Start () {
        player1Goals = 0;
        player2Goals = 0;
	}
	
	void Update () {
		if (player1Goals == maxGoals || player2Goals == maxGoals)
        {
            EndGame();
        }
	}

    public static void AddGoal (int whoseGoal)
    {
        if (whoseGoal == 1)
            player1Goals++;
        else
            player2Goals++;
        ResetGameAfterGoal(whoseGoal);
    }

    public static int GetPlayer1Goals()
    {
        return player1Goals;
    }

    public static int GetPlayer2Goals()
    {
        return player2Goals;
    }

    public static void ResetGameAfterGoal(int whoScored)
    {
        if (whoScored == 1)
        {

        }
        else
        {

        }
    }

    private void EndGame()
    {
        Debug.Log("End Game!");
    }
}
