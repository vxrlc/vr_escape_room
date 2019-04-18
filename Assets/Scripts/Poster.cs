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
    private Vector3 oldRot;

    private void Start()
    {
       audioSource.GetComponent<AudioSource>();
        oldRot = transform.rotation.eulerAngles;
        audioSource.volume = 0.0f;
        //audioSource.Play();

    }
    private void Update()
    {
       // Debug.Log(transform.rotation.eulerAngles + " " + oldRot);
        if (oldRot != transform.rotation.eulerAngles)
        {
            audioSource.volume = 1.0f;
            oldRot = transform.rotation.eulerAngles;
        }
        else
        {
            audioSource.volume = 0.0f;
        }
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
