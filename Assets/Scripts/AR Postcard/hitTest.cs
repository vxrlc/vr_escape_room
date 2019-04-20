using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hitTest : MonoBehaviour
{
    public GameManager gameManager;
    public Text scoreText;
    public ParticleSystem fireworks;
    public GameObject RestartButton;
    public GameObject vbBtnObject;
    public AudioSource fireworksSound;
    private bool hit = false;
    public GameObject countdown;
    public GameObject ball;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Ball" && !hit)
        {
            //vbBtnObject.GetComponent<VirtualButtonBehaviour>().enabled = true;
            //countdown.GetComponent<countdown>().gameOver = true;
            gameManager.ARCardScore++;
            scoreText.text = "Score: " + gameManager.ARCardScore.ToString();
            fireworks.Play();
            fireworksSound.Play();
            //InvokeRepeating("Vibrate", 0f, 0.5f);
            //RestartButton.SetActive(true);
            //vbBtnObject = GameObject.Find("VirtualButton");
           ball.SetActive(false);
            hit = true;
        }
       
    }
    
    private void Update()
    {
        if (!fireworks.isPlaying)
        {
            CancelInvoke();
        }
    }
}
