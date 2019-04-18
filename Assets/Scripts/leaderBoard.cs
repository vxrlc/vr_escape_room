using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class PlayerInfo
{
    public string name;
    public float time;

    public PlayerInfo(string name, float time)
    {
        this.name = name;
        this.time = time;
    }

}
public class leaderBoard : MonoBehaviour
{
    public Text userName;
    public Text display;
    public GameManager gameManager;
    private string formattedTime;

    private int start;
    private int end;

    private float recordTime;
    

    List<PlayerInfo> collectedStats;

    // Start is called before the first frame update
    void Start()
    {
      
        collectedStats = new List<PlayerInfo>();
       LoadLeaderBoard();
       
    }
    
    public void SubmitButton()
    {

        recordTime = gameManager.startTime - gameManager.timer;
        PlayerInfo stats = new PlayerInfo(userName.text, recordTime);
        collectedStats.Add(stats);
        userName.text = "";
      
        SortStats();


    }
    public void SortStats()
    {
        for(int i = collectedStats.Count - 1; i > 0; i--)
        {
            if (collectedStats[i].time < collectedStats[i-1].time)
            {
                PlayerInfo tempInfo = collectedStats[i - 1];

                collectedStats[i - 1] = collectedStats[i];

                collectedStats[i] = tempInfo;
            }
        }
        UpdatePlayerPrefsString();
    }
    void UpdatePlayerPrefsString()
    {
        string stats = "";
        for (int i = 0; i < collectedStats.Count; i++)
        {
            stats += collectedStats[i].name + ",";
            stats += collectedStats[i].time.ToString() + ",";

            PlayerPrefs.SetString("Leaderboards", stats);

            UpdateLeaderBoardVisual();
        }
    }
    void UpdateLeaderBoardVisual()
    {
        display.text = "";

        for (int i = 0; i <= collectedStats.Count - 1; i++)
        {
            int hours = Mathf.FloorToInt(collectedStats[i].time / 3600F);
            int minutes = Mathf.FloorToInt((collectedStats[i].time % 3600) / 60);
            int seconds = Mathf.FloorToInt(collectedStats[i].time % 60);
            formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            display.text += collectedStats[i].name + ": " + formattedTime + "\n";
        }
      
    }
    void LoadLeaderBoard()
    {
        string stats = PlayerPrefs.GetString("Leaderboards", "");

        string[] stats2 = stats.Split(',');

        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i],float.Parse(stats2[i+1]));

            collectedStats.Add(loadedInfo);

            UpdateLeaderBoardVisual();
        }
    }
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();

        display.text = "";
    }
}
