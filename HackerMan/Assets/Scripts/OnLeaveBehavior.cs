using UnityEngine;
using System;
using System.Collections;


/*
    Will invoke event if the targetObject ends a collision with its target name
*/


public class OnLeaveBehavior : MonoBehaviour {

    public GameObject targetName;

    public event EventHandler objectHit;

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == targetName.name)
        {
            objectHit.Invoke(this, EventArgs.Empty);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == targetName.name)
        {
            objectHit.Invoke(this, EventArgs.Empty);
        }
    }
}
