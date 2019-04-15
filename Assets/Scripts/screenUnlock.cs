using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenUnlock : MonoBehaviour
{

    public string computerPassword = "virtual";
    //public string enteredPassword; 

    public GameObject lockedScreen;
    public GameObject comboScreen;
    public bool correctPassword;
    private void Start()
    {
        //enterPassword();
    }
    public bool enterPassword(string enteredPassword)
    {
        if (computerPassword == enteredPassword)
        {
            lockedScreen.SetActive(false);
            comboScreen.SetActive(true);
            correctPassword = true; 
            
        } else
        {
            correctPassword = false;
        }
        return correctPassword;

    }
}
