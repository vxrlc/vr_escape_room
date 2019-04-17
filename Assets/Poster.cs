using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Poster : MonoBehaviour
{
    private CircularDrive cd;
    public AudioSource squeak;

    private void Start()
    {
        squeak.GetComponent<AudioSource>();
        

    }
    public void ResetOutAngle()
    {
        cd = gameObject.GetComponent<CircularDrive>();
        cd.outAngle = 0;
    }

    public void Update()
    {
        if(cd.maxAngle == -85)
        {
            squeak.Play();
        }
    }
}
