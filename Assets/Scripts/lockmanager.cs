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

    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (transform.parent.tag == other.tag)
        {
            interactable = other.transform.GetComponent<Interactable>();
            interactable.enabled = false;
            if (interactable.attachedToHand)
            {
                SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
               // hand
            }
           // other.gameObject.SetActive(false);
            key.SetActive(true);
            trigger.enabled = false;
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
