using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private float xVelocity;
    private float yVelocity;

	void Update ()
    {
        xVelocity = 0;
        yVelocity = 0;

		if (Input.GetKey(KeyCode.W))
        {
            yVelocity = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xVelocity = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
	}
}
