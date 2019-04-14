using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Poster : MonoBehaviour
{
    private CircularDrive cd;
  public void ResetOutAngle()
    {
        cd = gameObject.GetComponent<CircularDrive>();
        cd.outAngle = 0;
    }
}
