using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public Pin[] pinArray;
    public GameObject pinSet;
    public GameObject lane;
    public Animator animatorPinSetter;
    public PinCounter pinCounter;

    public void PerformAciton(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animatorPinSetter.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset)
        {
            pinCounter.Reset();
            animatorPinSetter.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            Debug.Log("EndGame");
            //animatorPinSetter.SetTrigger("resetTrigger");
        }
    }

    public void RaisePins()
    {
        foreach(Pin pin in pinArray)
        {
            if(pin != null)
            {
                pin.Raise();
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in pinArray)
        {
            if (pin != null)
            {
                pin.Lower();
            }
        }
    }

    public void RenewPins ()
    {
        GameObject ps = Instantiate(pinSet);
        ps.transform.parent = lane.transform;
    }


}
