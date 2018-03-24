using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    public Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    public void DragStart ()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }
	
    public void DragEnd ()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;
            float launchSpeedX = ((dragEnd.x - dragStart.x) / dragDuration) * .01f;
            float launchSpeedZ = ((dragEnd.y - dragStart.y) / dragDuration) * .01f;

            Vector3 launchVelocity = new Vector3(-launchSpeedX, 0, -launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }

    public void NudgeBall(float nudge)
    {
        if (!ball.inPlay)
        {
            float zPos = ball.transform.position.z;
            float xPos = Mathf.Clamp(ball.transform.position.x + nudge, -20f, 20f);
            float yPos = ball.transform.position.y;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }

    }

}
