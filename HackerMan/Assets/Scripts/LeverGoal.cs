using UnityEngine;
using System.Collections;
using System;


/*
    goal state will be reached when a level is pressed in its target UP or DOWN position
*/


public class LeverGoal : GoalState
{
    public GameObject lever;

    public leverState goal = leverState.OFF;

    public override bool CheckIfStateIsReached()
    {
        return lever.GetComponent<LeverControl>().trig == goal;
    }
}
