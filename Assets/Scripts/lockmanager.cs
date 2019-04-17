using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class lockmanager : MonoBehaviour
{
    
    public Animator lockOpen;
    public BoxCollider trigger;
    public GameObject mechanism;
    public GameManager gameManager;
    public GameObject lockParent;
    AudioSource audioSource;
    private Rigidbody rb;
    private bool unLocked = false;

    
   

    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform != null)
        { 
            if (other.transform.parent.GetComponent<keyManager>().inLock)
            {
                     
               //// if (other.transform.parent.rotation.eulerAngles.y >= (keyStartRotation.y + 90) && !unLocked)
               //// {
                                  //// Unlock();
                   // other.transform.parent.GetComponent<keyManager>().unLocked = true;
                   // unLocked = true;
               // }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (transform.parent.tag == other.transform.parent.tag)
            {
                //keyStartRotation = other.transform.parent.rotation.eulerAngles;
                ////= rb = other.transform.parent.GetComponent<Rigidbody>();
                other.transform.parent.GetComponent<keyManager>().inLock = true;
                other.transform.parent.GetComponent<keyManager>().unLocked = true;
                unLocked = true;
                lockOpen.enabled = true;
                audioSource.Play();
                lockParent.GetComponent<destroyLock>().unlocked = true;
                gameManager.locksUnlocked++;
                // rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

            }
        }
       
    }

}
