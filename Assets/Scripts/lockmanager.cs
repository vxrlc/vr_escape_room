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
    private int count = 0;

    
   

    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;
        audioSource = GetComponent<AudioSource>();

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (transform.parent.tag == other.transform.parent.tag && count == 0)
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
                gameManager.toggleHolding();
                // rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                count++;
            }
        }
       
    }

}
