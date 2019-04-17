using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace Valve.VR.InteractionSystem {

    public class phoneSound : MonoBehaviour
    {

        private AudioSource audioSource;
        public AudioClip[] messages;
        AudioClip phoneMessage;
        public int pNum;
    private Vector3 origPos;
    private Quaternion origRot;
    private Rigidbody rb;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        // get the original position of the phone, so it can be returned if dropped
        origPos = transform.position;
        origRot = transform.rotation;
        rb = gameObject.GetComponent<Rigidbody>();

        pNum = Random.Range(0, messages.Length);
    
        }

         public void playSound()
        {
            phoneMessage = messages[pNum];

            audioSource.clip = phoneMessage;

            audioSource.Play();
        }

       public void killSound()
        {
            audioSource.Stop();
        }
      public void resetPosition()
    {
        // reset the position/rotation/velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        gameObject.transform.position = origPos;
        gameObject.transform.rotation = origRot;
      
    }
    }

