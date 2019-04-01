using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo
{
    public string name;
    public string time;

    public PlayerInfo(string name, string time)
    {
        this.name = name;
        this.time = time;
    }

}
public class leaderBoard : MonoBehaviour
{
    public InputField userName;
    public Text display;
    public GameManager gameManager;

    List<PlayerInfo> collectedStats;

    // Start is called before the first frame update
    void Start()
    {
        collectedStats = new List<PlayerInfo>();
       LoadLeaderBoard();
        if (gameManager.gamePaused)
        {
            this.enabled = true;
        } else
        {
            this.enabled = false;
        }
    }

    public void SubmitButton()
    {
        PlayerInfo stats = new PlayerInfo(userName.text, gameManager.formattedTime);
        collectedStats.Add(stats);
        userName.text = "";
      
        SortStats();
    }
    public void SortStats()
    {
        for(int i = collectedStats.Count - 1; i > 0; i--)
        {
            int timeCurrent;
            int timePrevious;
            int.TryParse(collectedStats[i].time, out timeCurrent);
            int.TryParse(collectedStats[i - 1].time, out timePrevious);
            if (timeCurrent > timePrevious)
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
            stats += collectedStats[i].time + ",";

            PlayerPrefs.SetString("Leaderboards", stats);

            UpdateLeaderBoardVisual();
        }
    }
    void UpdateLeaderBoardVisual()
    {
        display.text = "";

        for (int i = 0; i <= collectedStats.Count - 1; i++)
        {
            display.text += collectedStats[i].name + ": " + collectedStats[i].time + "\n";
        }
    }
    void LoadLeaderBoard()
    {
        string stats = PlayerPrefs.GetString("Leaderboards", "");

        string[] stats2 = stats.Split(',');

        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i],stats2[i+1]);

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
