using UnityEngine;
using System.Collections;
using System;


/*
    Abstract class for goal states and fail states

    All goal / fail states must override the method: CheckIfStateIsReached
 */

abstract public class GameObjectiveState : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract bool CheckIfStateIsReached();
}



abstract public class GoalState : GameObjectiveState { }



abstract public class FailState : GameObjectiveState {

    public abstract char GetTimeCharAt(int i);
}



