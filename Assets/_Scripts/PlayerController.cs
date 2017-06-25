using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private float xVelocity;
    private float yVelocity;

    public float youShallNoPass;

    private bool isOnRightSide;

    void Start()
    {
        if (transform.position.x < 0)
        {
            youShallNoPass = -youShallNoPass;
            isOnRightSide = false;
        }
        else
            isOnRightSide = true;
            
    }

    void Update ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            for (int i=0; i < Input.touchCount; i++)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 10));
                if ( (touchedPos.x < -1f && !isOnRightSide) || (touchedPos.x > 1f && isOnRightSide) )
                {
                    touch = Input.GetTouch(i);
                    break;
                }
            }

            touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            if ( (touch.phase == TouchPhase.Moved) && ((touchedPos.x < -1f && !isOnRightSide) || (touchedPos.x > 1f && isOnRightSide)) )
            {
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = Vector3.MoveTowards(transform.position, touchedPos, speed * Time.deltaTime);
            }
        }

        if (Mathf.Abs(transform.position.x) < Mathf.Abs(youShallNoPass))
        {
            transform.position = new Vector3(youShallNoPass, transform.position.y, transform.position.z);
        }
	}
}
