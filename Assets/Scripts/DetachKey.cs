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
        rigidBody.useGravity = true;
    }
    public void DropKey()
    {
        rigidBody.useGravity = true;
     
    }
}
