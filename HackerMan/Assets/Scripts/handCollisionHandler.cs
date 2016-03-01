using UnityEngine;
using System.Collections;

public class handCollisionHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9, true);
    }
}
