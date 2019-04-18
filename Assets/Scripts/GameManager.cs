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
    public bool winGame = false;
    public int hours;
    public int minutes;
    public int seconds;
    public GameObject vent;
    public bool isHolding = false;
    public int ARCardScore = 0;
    private int index;
    public int locksUnlocked = 0;
    public int locksToWin = 3;
    public GameObject Teleport;
    public GameObject loseScreen;

    public GameObject keyboard;
    public GameObject leaderboard;

    public float drillRotation;
    public float drillTriggerSqueeze;

    public GameObject[] drillSpawnPoints;
    public GameObject drillPrefab;

    public int screwsUnscrewed = 0;

    private void Start()
    {
        startTime = timer;
      //     spawnDrill();

    }
    void spawnDrill()
    {
        // create a random number for one the spawn points
        index = Random.Range(0, drillSpawnPoints.Length);
        // spawn the drill at one of the random spawn points
        Instantiate(drillPrefab, drillSpawnPoints[index].transform.position, drillPrefab.transform.rotation);
        //drillPrefab.transform.SetParent(drillSpawnPoints[index].transform, false);
    }
    // determine if the player is holding an object - this is used to disable the laser pointer
    public void toggleHolding()
    {
        if (isHolding)
        {
            isHolding = false;
        } else if (!isHolding)
        {
            isHolding = true;
        }
    }
    private void WinGame()
    {
        isHolding = false;
        Invoke("showKeyboard", 0.5f);
        leaderboard.SetActive(true);
    }
    private void showKeyboard()
    {
        keyboard.SetActive(true);
    }
    private void LoseGame()
    {
        loseScreen.SetActive(true);
        leaderboard.SetActive(true);
        Teleport.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(isHolding);
        if (locksToWin == locksUnlocked)
        {
            winGame = true;
            WinGame();
        }
        else if (!winGame && timer >= 0f)
        {
            // countdown timer logic
            timer -= Time.deltaTime;
        } else
        {
            LoseGame();
        }
        hours = Mathf.FloorToInt(timer / 3600F);
        minutes = Mathf.FloorToInt((timer % 3600) / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        countDownText.text = formattedTime;
        // determine if both screws in the vent are unscrewed, if so, enable the collider on the vent to open
        if (screwsUnscrewed == 2)
        {
            vent.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
