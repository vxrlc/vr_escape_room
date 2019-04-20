using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Haptics : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean triggerAction;
    // public SteamVR_Action_Single actionStrength = SteamVR_Input.GetAction<SteamVR_Action_Single>("default", "Squeeze");
    public GameManager gameManager;  

    [Range(0f,0.79f)]
    public float time = 0.15f;

    [Range(0f, 300f)]
    public float amplitude = 100f;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.drillActive)
        {
            if (triggerAction.GetState(SteamVR_Input_Sources.RightHand))
            {

                hapticAction.Execute(0, 0, 0, 100, SteamVR_Input_Sources.RightHand);

            }
            if (triggerAction.GetState(SteamVR_Input_Sources.LeftHand))
            {

                hapticAction.Execute(0, 0, 0, 100, SteamVR_Input_Sources.LeftHand);

            }
        }
       



    }
   
}
