using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class RestartGame : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBtnObject;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObject = GameObject.Find("VirtualButton");
        vbBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //SceneManager.LoadScene("SampleScene");
    }
}
