using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PinSetter pinSetter;
    public Ball playerBall;
    public ScoreDisplay scoreDisplay;

    private List<int> rolls = new List<int>();

    public void Bowl(int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            pinSetter.PerformAciton(ActionMaster.NextAction(rolls));
            playerBall.Reset();
        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl()");
        }
        
        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong in FillRollCard()");
        }


    }

}
