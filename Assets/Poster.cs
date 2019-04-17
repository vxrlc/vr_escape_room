using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Poster : MonoBehaviour
{
    private CircularDrive cd;
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
       audioSource.GetComponent<AudioSource>();
        

    }
    public void ResetOutAngle()
    {
        cd = gameObject.GetComponent<CircularDrive>();
        cd.outAngle = 0;

        if (cd.maxAngle > 0)
        {
            audioSource.PlayOneShot(clip, 0.5f);
        }
    }

   
}
