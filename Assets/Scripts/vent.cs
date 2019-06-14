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
    private Rigidbody rb;
    private bool moving = false;
    public GameManager gameManager;
    public Collider col;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

    }
    
    // Update is called once per frame

    void Update()
    {
        if (gameManager.screwsUnscrewed == 2)
        {
            col.enabled = true;
        }
        if (rb.velocity.z > 0.1)
        {
            moving = true;
        }
        if (gameObject.transform.rotation.z <= 0)
        {

            ventRigidBody.useGravity = false;
            ventRigidBody.isKinematic = true;
            drive.outAngle = 0f;
       // } else if (!interactable.isHovering)
       } else if (gameObject.transform.rotation.z > 0)
       {
            ventRigidBody.useGravity = true;
           ventRigidBody.isKinematic = false;
    
        }
      

    }
   
}
