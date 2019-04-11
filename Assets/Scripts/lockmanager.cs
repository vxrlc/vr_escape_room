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

    private Rigidbody rb;
    private bool unLocked = false;

    private Vector3 keyStartRotation;
    
   

    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.GetComponent<keyManager>().inLock)
        {
                     
            if (other.transform.parent.rotation.eulerAngles.y >= (keyStartRotation.y + 90) && !unLocked)
            {
               
                Unlock();
                other.transform.parent.GetComponent<keyManager>().unLocked = true;
                unLocked = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.tag == other.transform.parent.tag)
        {
            keyStartRotation = other.transform.parent.rotation.eulerAngles;
            rb = other.transform.parent.GetComponent<Rigidbody>();
            other.transform.parent.GetComponent<keyManager>().inLock = true;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        }
    }
  
    public void Unlock()
    {
        lockOpen.enabled = true;
        Invoke("HideLock", 1f);
    }
    void HideLock()
    {
        gameManager.locksUnlocked++;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
