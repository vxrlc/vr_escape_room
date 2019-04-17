using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVentSound : MonoBehaviour
{
    AudioSource audioSource;
    float volume = 0f;
    float velocity;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;

    }

    private void OnTriggerEnter(Collider other)
    {
        // if the bottom of the vent hits the trigger, play the slam sound
        if (other.gameObject.name == "ventFrame") 
        {
            // get the velocity of the parent rigid body, if it positive the sound will be louder
            rb = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            velocity = rb.velocity.z;
            if (velocity > 0f)
            {
                audioSource.volume = 1.0f;
            } else if (velocity < 0f)
            {
                audioSource.volume = 0.3f;
            } else
            {
                audioSource.volume = 0.0f;
            }
         
           
            audioSource.Play();
        }
                
        
    }
}
