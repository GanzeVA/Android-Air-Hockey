using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    public int playerWhoGetsGoals;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            GameController.AddGoal(playerWhoGetsGoals);
            Destroy(collision.gameObject);
        }
    }
}
