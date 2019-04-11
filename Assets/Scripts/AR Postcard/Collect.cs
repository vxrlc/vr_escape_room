using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameManager gameManager;
    public Text score;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Ball")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            gameManager.ARCardScore++;

            score.text = "Score: " + gameManager.ARCardScore.ToString();
            gameObject.SetActive(false);
        }
    }
}
