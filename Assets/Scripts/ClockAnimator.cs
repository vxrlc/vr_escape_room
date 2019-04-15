using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour
{
    public Transform hours, minutes, seconds;

    private const float hoursToDegress = 360f / 12f;
    private const float minutesToDegress = 360f / 60f;
    private const float secondsToDegress = 360f / 60f;

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hours.localRotation = Quaternion.Euler(0f,  (float)time.TotalHours * hoursToDegress, 0f);
        minutes.localRotation = Quaternion.Euler(0f,  (float)time.TotalMinutes * minutesToDegress, 0f);
        seconds.localRotation = Quaternion.Euler(0f,  (float)time.TotalSeconds * secondsToDegress, 0f);
    }
}
