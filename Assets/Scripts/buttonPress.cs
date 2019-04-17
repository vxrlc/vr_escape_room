using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class buttonPress : MonoBehaviour
{
    public int keyNum;
   //public Animator keyAnimation;
    public GameObject safe;
    AudioSource audioSource;

    private SafeCombo ComboScript;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.25f;


    }
   public void NumberPress()
    {
       ComboScript = safe.GetComponent<SafeCombo>();
        ComboScript.NumberGuess(keyNum);
        audioSource.Play();
    }

    public void ClearGuess()
    {
        ComboScript = safe.GetComponent<SafeCombo>();
        ComboScript.ClearGuess();
        audioSource.Play();
    }
    public void SubmitGuess()
    {
        ComboScript = safe.GetComponent<SafeCombo>();
        ComboScript.SubmitGuess();
        audioSource.Play();
    }
}
