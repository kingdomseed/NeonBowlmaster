using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};

    public static Action NextAction(List<int> rollsOrig)
    {
        List<int> rolls = new List<int>(rollsOrig);
        Action nextAction = Action.EndTurn;
        int roll = rolls[rolls.Count - 1];

        // pad strikes so we can rolls.Count frames correctly
        for (int i = 0; i < rolls.Count && i < 18; i += 2)
        {
            if (rolls[i] == 10)
            { // Strike
                rolls.Insert(i, 0); // Insert virtual 0 after strike
            }
        }

        if (rolls.Count >= 21)
        {
            nextAction = Action.EndGame;
        }
        else if (rolls.Count >= 19 && roll == 10)
        { // Handle last-frame special cases
            nextAction = Action.Reset;
        }
        else if (rolls.Count == 20)
        {
            if (rolls[18] == 10 && rolls[19] < 10)
            { // Roll 21 awarded
                nextAction = Action.Tidy;
            }
            else if (rolls[18] + rolls[19] == 10)
            { // Spare, extra roll
                nextAction = Action.Reset;
            }
            else
            {
                nextAction = Action.EndGame;
            }
        }
        else if (rolls.Count % 2 != 0 && roll != 10)
        { // First bowl of frame & not strike
            nextAction = Action.Tidy;
        }

        return nextAction;
    }
}