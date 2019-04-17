using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class vent : MonoBehaviour
{
   
    public Rigidbody ventRigidBody;
    public CircularDrive drive;
    private Interactable interactable;
    public SteamVR_Action_Boolean grabVent;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();

        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    
        void Update()
    {


        if (gameObject.transform.rotation.z <= 0)
        {

            ventRigidBody.useGravity = false;
            ventRigidBody.isKinematic = true;
            drive.outAngle = 0f;
       // } else if (!interactable.isHovering)
       } else if (!grabVent.GetState(SteamVR_Input_Sources.Any) && gameObject.transform.rotation.z > 0)
       {
            ventRigidBody.useGravity = true;
           ventRigidBody.isKinematic = false;

            audioSource.PlayOneShot(clip, 0.5f);
        }
    }
   
}
