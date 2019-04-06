﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class screwDriver : MonoBehaviour
{
    public Transform modelTrigger;
    public float triggerRot;
    public Transform drillBit;
    public float squeeze = 0;
    public SteamVR_Action_Single actionSqueeze = SteamVR_Input.GetAction<SteamVR_Action_Single>("default", "Squeeze");

    private Quaternion trigSRot;
    private Interactable interactable;
    public float rotation = 0;  

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        trigSRot = modelTrigger.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        squeeze = 0;
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            squeeze = actionSqueeze.GetAxis(hand);
           
        }
     

        modelTrigger.localRotation = trigSRot;
        modelTrigger.Rotate(squeeze * triggerRot, 0, 0, Space.Self);
        rotation = squeeze * triggerRot;
        drillBit.Rotate(0, 0, squeeze * triggerRot, Space.Self);

    }
   
}
