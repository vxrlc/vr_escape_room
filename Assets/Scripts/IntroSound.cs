using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour
{

    AudioSource audioSource;
    //public AudioClip clip;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audioSource.PlayDelayed(2);
    }

  
}
