using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public Text timerText;
    public float timer = 30;
    public GameObject RestartButton;
    public GameObject vbBtnObject;
    public bool gameOver = false;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && !gameOver)
        {
            timer -= Time.deltaTime;
            //timerText.text = "Time: " + timer.ToString("F0");
        }
        else if (timer < 0)
        {
            //RestartButton.SetActive(true);
            // vbBtnObject = GameObject.Find("VirtualButton");
            // vbBtnObject.GetComponent<VirtualButtonBehaviour>().enabled = true;
            ball.SetActive(false);
        }
    }
}
