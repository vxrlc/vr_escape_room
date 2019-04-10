using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class lockmanager : MonoBehaviour
{
    public Animator lockOpen;
    public GameObject key;
    public BoxCollider trigger;

    private Interactable interactable;
    private Throwable throwable;
    private Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.tag == other.transform.parent.tag)
        {
          //  interactable = other.transform.GetComponent<Interactable>();
            rb = other.transform.parent.GetComponent<Rigidbody>();
            //Destroy(other.transform.parent.GetComponent<Throwable>());

           // if (interactable.attachedToHand)
          //  {
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           // }
           // key.SetActive(true);
            //trigger.enabled = false;
        }
    }
   public void Unlock()
    {
        lockOpen.enabled = true;
        Invoke("HideLock", 1f);
    }
    void HideLock()
    {
        this.gameObject.SetActive(false);
    }
}
