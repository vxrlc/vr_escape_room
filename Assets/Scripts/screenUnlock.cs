using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenUnlock : MonoBehaviour
{

    public string[] computerPassword;
    //public string enteredPassword; 

    public GameObject lockedScreen;
    public GameObject comboScreen;
    public GameObject phone;
    public bool correctPassword;
    public Material lockedMat;
    public Material unlockedMat;
    private Material[] origMat;
    private int passwordIndex;
    private void Start()
    {
        //changes the screen for the interactive computer to the default locked screen
        origMat = GetComponent<MeshRenderer>().materials;
        origMat[1] = lockedMat;
        GetComponent<MeshRenderer>().materials = origMat;
       
        
    }
    public bool enterPassword(string enteredPassword)
    {
        passwordIndex = phone.GetComponent<phoneSound>().pNum;
        Debug.Log("index " + passwordIndex);
        Debug.Log("entered " + enteredPassword + " " + "correct " + computerPassword[passwordIndex]);
        if (computerPassword[passwordIndex] == enteredPassword)
        {
            origMat = GetComponent<MeshRenderer>().materials;
            origMat[1] = unlockedMat;
            GetComponent<MeshRenderer>().materials = origMat;
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
