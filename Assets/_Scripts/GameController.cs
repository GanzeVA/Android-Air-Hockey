using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static int player1Goals;
    private static int player2Goals;
    public int maxGoals;

    public float ballDistanceFromMiddle;
    private static float ballDistance;

    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    private static GameObject ballObject;
    private static GameObject player1Object;
    private static GameObject player2Object;

    private static Vector3 player1Position;
    private static Vector3 player2Position;

    void Start () {
        ballDistance = ballDistanceFromMiddle;
        player1Position = player1.transform.position;
        player2Position = player2.transform.position;
        ballObject = ball;
        player1Object = player1;
        player2Object = player2;
        StartGame();
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

    private void StartGame()
    {
        player1Goals = 0;
        player2Goals = 0;
        ball.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player1.transform.position = player1Position;
        player2.transform.position = player2Position;
        player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private static void ResetGameAfterGoal(int whoScored)
    {
        if (whoScored == 1)
        {
            ballObject.transform.position = new Vector3(ballDistance, 0.0f, 0.0f);
            ballObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            ballObject.transform.position = new Vector3(-ballDistance, 0.0f, 0.0f);
            ballObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        player1Object.transform.position = new Vector3(-6.0f, 0.0f, 0.0f);
        player2Object.transform.position = player2Position;
        player1Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private void EndGame()
    {
        Debug.Log("End Game!");
    }
}
