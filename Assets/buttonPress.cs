using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class buttonPress : MonoBehaviour
{
    public int keyNum;
    public Animator keyAnimation;
    public GameObject safe;

    private SafeCombo ComboScript;

    private void Start()
    {
        //keyAnimation.enabled = false;

     
    }
   public void NumberPress()
    {
        Debug.Log("press");
       // ComboScript = safe.GetComponent<SafeCombo>();
      
       
    }
}
