using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float maxSpeed;

    private float xVelocity;
    private float yVelocity;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            if (rb2d.velocity.x < 0)
                xVelocity = -maxSpeed;
            else
                xVelocity = maxSpeed;
        }
        else
            xVelocity = rb2d.velocity.x;

        if (Mathf.Abs(rb2d.velocity.y) > maxSpeed)
        {
            if (rb2d.velocity.y < 0)
                yVelocity = -maxSpeed;
            else
                yVelocity = maxSpeed;
        }
        else
            yVelocity = rb2d.velocity.y;

        rb2d.velocity = new Vector2(xVelocity, yVelocity);
    }
}
