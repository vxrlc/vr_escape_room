using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float startTime;
    public Text countDownText;
    public string formattedTime;
    public bool gamePaused = false;
    public bool winGame = false;
    public int hours;
    public int minutes;
    public int seconds;
    public GameObject vent;

    public int screwsUnscrewed = 0;

    private void Start()
    {
        startTime = timer;
      
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        hours = Mathf.FloorToInt(timer / 3600F);
        minutes = Mathf.FloorToInt((timer % 3600) / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        countDownText.text = formattedTime;
        Debug.Log(screwsUnscrewed);
        if (screwsUnscrewed == 2)
        {
            vent.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
