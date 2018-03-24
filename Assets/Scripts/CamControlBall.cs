using UnityEngine;
using System.Collections;

public class CamControlBall : MonoBehaviour {

    public Ball ball;
    public Vector3 camStartPosition;
    private Vector3 offset;
    
	void Start ()
    {
        offset = transform.position - ball.transform.position;
        camStartPosition = transform.position;
    }
	
	void Update ()
    {
        if(transform.position.z >= 20)
        {
            transform.position = ball.transform.position + offset;
        }
        if(ball.inPlay == false)
        {
            transform.position = camStartPosition;
        }
    }
}
