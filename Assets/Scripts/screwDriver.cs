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
  
   
    

    public AudioSource drillSound;
    float minVol = 0f;
    float maxVol = 1f;

    float minPitch = 0.5f;
    float maxPitch = 1.0f;

 




    private Quaternion trigSRot;
    private Interactable interactable;
    private GameManager gameManager;
    public float rotation = 0;
    public BoxCollider pickUpCollider;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        trigSRot = modelTrigger.localRotation;
        gameManager = FindObjectOfType<GameManager>() as GameManager;
        drillSound = GetComponent<AudioSource>();
      
    }
    // function to indicate the drill is being held, used to prevent laser pointer from being used
    public void toggleHandle()
    {
        pickUpCollider.enabled = false;
        gameManager.toggleHolding();
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

        if (squeeze  >= 0.002)
        {
           
            gameManager.drillActive = true;
        } else
        {
            gameManager.drillActive = false;
        }
        modelTrigger.localRotation = trigSRot;
        modelTrigger.Rotate(squeeze * triggerRot, 0, 0, Space.Self);
        gameManager.drillRotation = squeeze * triggerRot;
        gameManager.drillTriggerSqueeze = squeeze;
        drillBit.Rotate(0, 0, squeeze * triggerRot, Space.Self);

       
      //sets pitch based on the value of the squeeze single
        drillSound.pitch = Mathf.Lerp(minPitch, maxPitch, squeeze);

        // drill soudn is always playing, sets vol based on value of squeeze
        drillSound.volume = Mathf.Lerp(minVol, maxVol, (squeeze/2));

       
        


    }

    
}
