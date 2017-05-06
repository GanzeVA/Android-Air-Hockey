using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private float xVelocity;
    private float yVelocity;

    public float youShallNoPass;

    void Start()
    {
        if (transform.position.x < 0)
            youShallNoPass = -youShallNoPass;
    }

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

        if (Input.touchCount > 0)
        {
            Debug.Log("Touched");
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = Vector3.MoveTowards(transform.position, touchedPos, speed * Time.deltaTime);
            }
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);

        if (Mathf.Abs(transform.position.x) < Mathf.Abs(youShallNoPass))
        {
            transform.position = new Vector3(youShallNoPass, transform.position.y, transform.position.z);
        }
	}
}
