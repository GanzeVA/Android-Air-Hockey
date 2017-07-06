using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float respawnDelay;

    private static int player1Goals;
    private static int player2Goals;
    public int maxGoals;

    public bool isGoal;

    public float ballDistanceFromMiddle;
    private static float ballDistance;
    private static float ballDistanceAct;

    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    private static GameObject ballObject;
    private static GameObject player1Object;
    private static GameObject player2Object;

    private static Vector3 player1Position;
    private static Vector3 player2Position;

    public GameObject redGoalText;
    public GameObject greenGoalText;

    public GameObject endGameMenu;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public Text endGameText;

    public Text countDownText;
    public Text countDownTextBack;

    public bool gameOn = false;

    private bool vsCPU = false;

    void Start () {
        if (SceneManager.GetActiveScene().name == "GameCPU")
            vsCPU = true;

        isGoal = false;
        ballDistance = ballDistanceFromMiddle;
        player1Position = player1.transform.position;
        player2Position = player2.transform.position;
        ballObject = ball;
        player1Object = player1;
        player2Object = player2;
        StartGame();
	}

    public void AddGoal (int whoseGoal)
    {
        gameOn = false;
        isGoal = true;
        if (whoseGoal == 1)
        {  
            greenGoalText.SetActive(true);
            player1Goals++;
            ballDistanceAct = ballDistance;
        }
        else
        {
            redGoalText.SetActive(true);
            player2Goals++;
            ballDistanceAct = -ballDistance;
        }
        if (player1Goals == maxGoals || player2Goals == maxGoals)
        {
            EndGame();
        }
        else
            StartCoroutine("AfterGoalCo");
    }

    public static int GetPlayer1Goals()
    {
        return player1Goals;
    }

    public static int GetPlayer2Goals()
    {
        return player2Goals;
    }

    public void StartGame()
    {
        player1.SetActive(true);
        player2.SetActive(true);
        redGoalText.SetActive(false);
        greenGoalText.SetActive(false);
        endGameMenu.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(false);
        player1Goals = 0;
        player2Goals = 0;
        ballDistanceAct = 0.0f;
        StartCoroutine("ResetGameCo");
    }

    private IEnumerator AfterGoalCo()
    {
        ballObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ballObject.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        gameOn = true;
        pauseButton.SetActive(true);
        redGoalText.SetActive(false);
        greenGoalText.SetActive(false);
        ballObject.transform.position = new Vector3(ballDistanceAct, 0.0f, 0.0f);
        ballObject.SetActive(true);
        player1Object.transform.position = player1Position;
        player2Object.transform.position = player2Position;
        player1Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        isGoal = false;
    }

     private IEnumerator ResetGameCo()
    {
        ballObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ballObject.SetActive(false);

        countDownText.text = "3";
        countDownTextBack.text = countDownText.text;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(respawnDelay / 3);
        countDownText.text = "2";
        countDownTextBack.text = countDownText.text;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(respawnDelay / 3);
        countDownText.text = "1";
        countDownTextBack.text = countDownText.text;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(respawnDelay / 3);
        countDownText.text = "";
        countDownTextBack.text = countDownText.text;

        gameOn = true;
        pauseButton.SetActive(true);
        redGoalText.SetActive(false);
        greenGoalText.SetActive(false);
        ballObject.transform.position = new Vector3(ballDistanceAct, 0.0f, 0.0f);
        ballObject.SetActive(true);
        player1Object.transform.position = player1Position;
        player2Object.transform.position = player2Position;
        player1Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        isGoal = false;
    }

    private void EndGame()
    {
        Debug.Log("End Game!");
        ballObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        redGoalText.SetActive(false);
        greenGoalText.SetActive(false);
        ballObject.SetActive(false);
        gameOn = false;
        player1Object.transform.position = player1Position;
        player2Object.transform.position = player2Position;
        player1Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (player1Goals > player2Goals)
        {
            player2.SetActive(false);
            endGameText.text = "Green Player Won!";
        }
        else
        {
            player1.SetActive(false);
            if (vsCPU)
                endGameText.text = "CPU Won!";
            else
                endGameText.text = "Red Player Won!";
        }
        endGameMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused!");
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0.0f;

    }
    
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
    }

}
