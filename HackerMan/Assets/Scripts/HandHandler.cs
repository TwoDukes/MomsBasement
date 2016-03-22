using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandHandler : MonoBehaviour
{

    public GameObject attachObject, handModel;
    public float pullPower;

    Rigidbody attachPoint;
    GameObject CurrentHeld = null;
    bool trig = false;

    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;
    public float jointBreak;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        attachPoint = attachObject.GetComponent<Rigidbody>();
        
        
    }

    void FixedUpdate()
    {
        //turns on hand models if they are off
        if (attachObject.activeSelf == false){
            attachObject.SetActive(true);
        }

        //gets the controllers to be checked for button input
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        //checks controllers for input
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
            trig = true;
            
        }
        else if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            trig = false;
            CurrentHeld = null;
            //turns hand model back on
            handModel.GetComponent<MeshRenderer>().enabled = true;
        }
        

        //if object isnt being held and the trigger is being held
        if (joint == null && trig)
        {

          
            if (CurrentHeld != null)
            {
                handModel.GetComponent<MeshRenderer>().enabled = false;
                handModel.GetComponent<Collider>().enabled = false;
                //for objects that arent attached to the enviroment
                if (CurrentHeld.tag == "Throwable")
                {

                    //(TEST BELOW FOR RESULTS)
                    //go.transform.position = attachPoint.transform.position;

                    joint = CurrentHeld.AddComponent<FixedJoint>();
                    joint.connectedBody = attachPoint;
                    joint.breakForce = jointBreak; 
                }

                //for object that are attached to the enviroment
                else if (CurrentHeld.tag == "moveable")
                {

                    Rigidbody puller = CurrentHeld.GetComponent<Rigidbody>();
                    Vector3 pullPos = CurrentHeld.transform.position;
                    Vector3 aimPos = attachObject.transform.position;

                    puller.AddForce((aimPos - pullPos) * pullPower);

                }
            }
        }
        //if object is being held that isnt attached to the enviroment
        //and the trigger isnt being held
        else if (joint != null && !trig)
        {
            
            GameObject go = joint.gameObject;
            Rigidbody rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(joint);
            joint = null;
            CurrentHeld = null;
            

            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.


            //handles physics on objects being let go of
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

       // print("TRIG " + trig + " " +gameObject.name);


        
    }

    
    void OnTriggerStay(Collider col)
    {
        //if object can be held/moved and no object is currently being held and the trigger is held
        if(col.tag == "Throwable" || col.tag == "moveable" && CurrentHeld == null && trig)
        {
            //turns hand off
            //handModel.SetActive(false);

            CurrentHeld = col.gameObject;
        }
        
    }

   void OnTriggerExit(Collider col) {

        if (col.gameObject == CurrentHeld)
        {
            handModel.GetComponent<Collider>().enabled = true;
           // handModel.GetComponent<MeshRenderer>().enabled = true;
            CurrentHeld = null;
        }
    }
    
}
