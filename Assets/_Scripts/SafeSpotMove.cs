using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpotMove : MonoBehaviour {

    public float maxY;
    public float speed;

    private bool goingUp = true;

	void Update () {
		if (goingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, maxY), speed * Time.deltaTime);
            if (transform.position.y == maxY)
                goingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, -maxY), speed * Time.deltaTime);
            if (transform.position.y == -maxY)
                goingUp = true;
        }
    }
}
