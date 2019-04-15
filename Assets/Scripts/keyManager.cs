﻿using System.Collections;
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

    protected virtual void OnAttachedToHand(Hand hand)
    {
        playerHand = hand;

    }
   
    private void HandAttachedUpdate()
    {
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
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }
 }
