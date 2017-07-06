using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    public ParticleSystem goalParticle;
    public int playerWhoGetsGoals;

    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" && !gameController.isGoal)
        {
            Instantiate(goalParticle, collision.transform.position, collision.transform.rotation);
            gameController.AddGoal(playerWhoGetsGoals);
        }
    }
}
