using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool inPlay = false;

    private AudioSource ballAudio;
    private Rigidbody rb;
    private Vector3 ballStartPosition;

    
	private void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        ballAudio = GetComponent<AudioSource>();
        rb.useGravity = false;
        ballStartPosition = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        rb.useGravity = true;
        inPlay = true;
        rb.velocity = velocity;
        ballAudio.Play();
    }

    public void Reset()
    {
        transform.position = ballStartPosition;
        inPlay = false;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
    }
}
