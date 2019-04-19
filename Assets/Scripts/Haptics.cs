using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Haptics : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean triggerAction;
    // public SteamVR_Action_Single actionStrength = SteamVR_Input.GetAction<SteamVR_Action_Single>("default", "Squeeze");

  

    [Range(0f,0.79f)]
    public float time = 0.15f;

    [Range(95f, 175f)]
    public float frequency = 110f;

 
    // Update is called once per frame
    void Update()
    {
         

        if (triggerAction.GetStateDown(SteamVR_Input_Sources.LeftHand))

        {
            Pulse(time, frequency, 100, SteamVR_Input_Sources.LeftHand);
           
        }
        if (triggerAction.GetStateDown(SteamVR_Input_Sources.RightHand))

        {
            Pulse(time, frequency, 100, SteamVR_Input_Sources.RightHand);
        }
    
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);

       // print("Pulse " + source.ToString());
    }
}
