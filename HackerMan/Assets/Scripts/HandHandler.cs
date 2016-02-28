using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandHandler : MonoBehaviour
{

    public Rigidbody attachPoint;

    GameObject CurrentHeld = null;
    bool trig;

    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
            trig = true;
        }
        else if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            trig = false;
            CurrentHeld = null;
        }


        if (joint == null && trig)
        {
            var go = CurrentHeld;
            go.transform.position = attachPoint.transform.position;

            joint = go.AddComponent<FixedJoint>();
            joint.connectedBody = attachPoint;
        }
        else if (joint != null && !trig)
        {
            var go = joint.gameObject;
            var rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(joint);
            joint = null;
            

            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.

            var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(device.velocity);
                rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                rigidbody.velocity = device.velocity;
                rigidbody.angularVelocity = device.angularVelocity;
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Throwable" && CurrentHeld == null && trig)
        {
            CurrentHeld = col.gameObject;
        }
    }

    //void OnTriggerExit(Collider col)
    //{
    //    if (!trig)
    //    {
    //        CurrentHeld = null;
    //    }
    //}
}
