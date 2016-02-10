using UnityEngine;
using System.Collections;
using System;


/*
    Goal state will be reached if an object is taken out of its container.

    Both objects must be defined in the unity editor.


*/

public class TakeOutObjectGoal : GoalState
{

    public GameObject container;
    public GameObject objectInContainer;

    private bool isTheObjectIn = true;

    public override bool CheckIfStateIsReached()
    {
        return !isTheObjectIn;
    }
    
    void Start()
    {
        container.GetComponent<OnLeaveBehavior>().objectHit += TakeOutObjectGoal_objectHit;
    }

    private void TakeOutObjectGoal_objectHit(object sender, EventArgs e)
    {
        isTheObjectIn = false;
    }
}
