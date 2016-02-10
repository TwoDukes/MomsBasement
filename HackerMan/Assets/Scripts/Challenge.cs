using UnityEngine;
using System.Collections;
using System;


/*
    Attach this component to an empty game object to designate it as a challenge

    NOTE: ALL CHALLENGES MUST BE ACCOMPANIED BY A GOALSTATE AND FAILSTATE SCRIPT
          Those scripts must also be attached to the object.
*/

public class Challenge : MonoBehaviour {

    public event EventHandler goalReached;
    public event EventHandler failStateReached;

    public string challengeDescription = "TEMP DESCRIPTION";
    public int order = 0;

    public bool IsStarted = false;

    // Goal
    public  GoalState goalState;
    // Fail State
    public  FailState failState;

	// Use this for initialization
	void Start () {

        //goalState.enabled = false;
        //failState.enabled = false;
        
    }


    // use this to initialize any game specific logic
    public void StartChallenge()
    {
        //goalState.enabled = true;
        //failState.enabled = true;
        IsStarted = true;
        this.gameObject.SetActive(true);
        goalState = GetComponent<GoalState>();
        failState = GetComponent<FailState>();
        Debug.Log("chellege staert");
    }

	// Will check the challenge's goal and fail state
    // if a goal state or fail state has been reached, it will
    // invoke The mission control fail/success methods
	void Update () {
        if (IsStarted && goalState.CheckIfStateIsReached())
        {
            Debug.Log("goal reached");
            goalReached.Invoke(this, EventArgs.Empty);
            Destroy(failState);
            Destroy(goalState);
            IsStarted = false;
        }
        if (IsStarted && failState.CheckIfStateIsReached())
        {
            Debug.Log("fail reached");
            failStateReached.Invoke(this, EventArgs.Empty);
            Destroy(failState);
            Destroy(goalState);
            IsStarted = false;
        }
    }

    // Will get called when the goal state is reached.
    // use this to initiate any challenge specific events
    protected virtual void OnGoalReached(EventArgs e)
    {
        EventHandler handler = goalReached;
        if (handler != null)
        {
            handler(this, e);
        }
    }


    // Will get called when the fail state is reached.
    // use this to initiate any challenge specific events
    protected virtual void OnFailStateReached(EventArgs e)
    {
        EventHandler handler = failStateReached;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    // NOTE: WILL NOT WORK IF A FAILSTATE DOES NOT CONTAIN TIME
    public char GetTimeUntilFail(int i)
    {
        return failState.GetTimeCharAt(i);
    }
}
