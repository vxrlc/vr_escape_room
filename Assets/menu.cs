using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class menu : MonoBehaviour
{
    public void loadLevel(string levelName)
    {
        SteamVR_LoadLevel.Begin(levelName);
    }
    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
