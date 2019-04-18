using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class destroyLock : MonoBehaviour
{
    Hand playerHand;
    public bool unlocked = false;
    AudioSource audioSource;
    public GameManager gameManager;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected virtual void OnAttachedToHand(Hand hand)
    {
        playerHand = hand;

    }
    private void HandAttachedUpdate()
    {
        if (unlocked)
        {
            Invoke("DestroyLock", 1F);
        }
        
       
    }
    private void DestroyLock()
    {

        playerHand.DetachObject(this.gameObject);
        gameManager.toggleHolding();
        Destroy(this.gameObject);
    }
}
