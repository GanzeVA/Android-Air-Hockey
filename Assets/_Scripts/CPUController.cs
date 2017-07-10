using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUController : MonoBehaviour {

    public float speed;
    public float youShallNoPass;

    public Transform safeSpot;

    private bool isOnRightSide;
    private GameObject ball;
    private GameController gameController;

    private bool ballOnMySide;

    void Start () {
        gameController = FindObjectOfType<GameController>();
        ball = GameObject.Find("Ball");
        if (transform.position.x < 0)
        {
            youShallNoPass = -youShallNoPass;
            isOnRightSide = false;
        }
        else
            isOnRightSide = true;
    }
	
	void Update () {
        if (((isOnRightSide && ball.transform.position.x >= 0) || (!isOnRightSide && ball.transform.position.x <= 0)) && gameController.gameOn)
            ballOnMySide = true;
        else
            ballOnMySide = false;

        transform.rotation = Quaternion.identity;

        if (ballOnMySide)
        {
            transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, speed * Time.deltaTime);
        }
        else if (gameController.gameOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, safeSpot.position, speed * Time.deltaTime);
        }


        if (Mathf.Abs(transform.position.x) < Mathf.Abs(youShallNoPass))
        {
            transform.position = new Vector3(youShallNoPass, transform.position.y, transform.position.z);
        }
    }
}
