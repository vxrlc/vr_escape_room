using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class keyManager : MonoBehaviour
{
    Hand playerHand;
    public bool inLock = false;
    public bool unLocked = false;
    private Rigidbody rb;
    private Vector3 origPos;
    private Quaternion origRot;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void getOrigPos()
    {
        origPos = transform.position;
        origRot = transform.rotation;
  
    }
    public void snapToHand()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        gameObject.transform.position = origPos;
        gameObject.transform.rotation = origRot;
    }
    protected virtual void OnAttachedToHand(Hand hand)
    {
        playerHand = hand;

    }
   
    private void HandAttachedUpdate()
    {
        origPos = transform.position;
        origRot = transform.rotation;
        if (inLock && unLocked)
        {
            Invoke("DestroyKey", 1f);
        }
    }
    private void DestroyKey()
    {
        playerHand.DetachObject(this.gameObject);
        Destroy(this.gameObject);
    }
    public void UnFreeze()
    {
       
        rb.constraints = RigidbodyConstraints.None;
    }
 }
