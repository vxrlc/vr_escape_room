using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    public Text countDownText;
    public string formattedTime;
    public bool gamePaused = false;
    private void Update()
    {
        timer -= Time.deltaTime;

        int hours = Mathf.FloorToInt(timer / 3600F);
        int minutes = Mathf.FloorToInt((timer % 3600) / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        countDownText.text = formattedTime;
    }
}
