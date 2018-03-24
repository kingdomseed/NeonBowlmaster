using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distToRaise = 0.5f;

    private Vector3 pinAngle;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsStanding();
    }

    public bool IsStanding()
    {
        pinAngle = transform.rotation.eulerAngles;
        if (Mathf.Abs(pinAngle.z) < standingThreshold || Mathf.Abs(pinAngle.x) < standingThreshold)
            return true;
        else
            return false;
    }

    public void Raise()
    {
       if(IsStanding())
        {
            rb.useGravity = false;
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(0, 270f, 0);
        }
    }

    public void Lower()
    {
        if(IsStanding())
        {
            transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
        }
        rb.useGravity = true;
    }
}
