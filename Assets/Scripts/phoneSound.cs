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

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
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
    }

