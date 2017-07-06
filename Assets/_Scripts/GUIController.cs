using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Text scoreText;
    public Text scoreTextBack;

	void Start () {
        scoreText.text = "0 : 0";
        scoreTextBack.text = "0 : 0";
    }
	
	void Update () {
        scoreText.text = GameController.GetPlayer1Goals() + " : " + GameController.GetPlayer2Goals();
        scoreTextBack.text = GameController.GetPlayer1Goals() + " : " + GameController.GetPlayer2Goals();
    }
}
