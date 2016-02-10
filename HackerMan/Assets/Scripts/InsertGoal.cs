using UnityEngine;
using System.Collections;
using System;

/*
    Goal will be reached when an object collides with its targetContainer

    both objects are defined in the unity editor
*/


public class InsertGoal : GoalState
{
    public GameObject objectsToInsert;
    public GameObject targetContainer;

    ConfigurableJoint targetJoint;

    private float maxDistance;

    private bool objectIsInContainer = false;

    void Start()
    {
        
        objectsToInsert = GameObject.Find(objectsToInsert.name);

        targetContainer = GameObject.Find(targetContainer.name);
        targetJoint = targetContainer.GetComponent<ConfigurableJoint>();

        targetContainer.GetComponent<OnTouchBehavior>().objectHit += InsertGoal_objectHit;

        maxDistance = targetJoint.linearLimit.limit;
        
    }

    private void InsertGoal_objectHit(object sender, EventArgs e)
    {
        objectIsInContainer = true;
    }

    public override bool CheckIfStateIsReached()
    {
        return objectIsInContainer;
    }
}
