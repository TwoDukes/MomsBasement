using UnityEngine;
using System.Collections;
using System;



/*
    Will invoke event if the targetObject begins a collision with its target name
*/

public class OnTouchBehavior : MonoBehaviour {

    //public GameObject targetName;

    public event EventHandler objectHit;

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        //Debug.Log(objectHit);
        if (objectHit != null)
        {
            Debug.Log("invoking");
            objectHit.Invoke(other.gameObject, EventArgs.Empty);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (objectHit != null)
            objectHit.Invoke(other.gameObject, EventArgs.Empty);
    }
}
