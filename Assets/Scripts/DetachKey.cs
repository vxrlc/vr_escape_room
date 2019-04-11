using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachKey : MonoBehaviour
{
    public Rigidbody rigidBody;


    public void Detach()
    {
       
        transform.parent = null;
        rigidBody.isKinematic = false;
    }
    public void DropKey()
    {
        rigidBody.useGravity = true;
     
    }
}
