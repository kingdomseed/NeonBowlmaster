using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text pinCountText;
    public bool ballOutOfPlay = false;
    public Pin[] pinArray;
    public GameManager gm;

    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    private void Update()
    {
        pinCountText.text = countStanding().ToString();
        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            pinCountText.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    private void UpdateStandingCountAndSettle()
    {
        int currentStanding = countStanding();

        if (lastStandingCount != currentStanding)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        int standing = countStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gm.Bowl(pinFall);

        ballOutOfPlay = false;
        lastStandingCount = -1;
        pinCountText.color = Color.green;
    }

    public int countStanding()
    {
        int pinCount = 0;

        foreach (Pin pin in pinArray)
        {
            if (pin != null)
            {
                if (pin.IsStanding())
                {
                    pinCount++;
                }
            }
        }
        return pinCount;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerBall")
        {
            ballOutOfPlay = true;
        }
    }
}
