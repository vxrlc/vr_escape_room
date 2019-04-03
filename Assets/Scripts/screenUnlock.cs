using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenUnlock : MonoBehaviour
{

    public string computerPassword = "virtual";
    //public string enteredPassword;

    public GameObject lockedScreen;
    public GameObject comboScreen;
    private void Start()
    {
        //enterPassword();
    }
    public void enterPassword(string enteredPassword)
    {
        if (computerPassword == enteredPassword)
        {
            lockedScreen.SetActive(false);
            comboScreen.SetActive(true);
        }
    }
}
