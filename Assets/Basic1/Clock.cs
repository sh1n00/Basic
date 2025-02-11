using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    const float cHoursToDegress = -30f, cMintuesToDegrees = -6f, cSecondsToDegrees = -6f;
    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        mHoursPivot.localRotation = Quaternion.Euler(0f, 0f, cHoursToDegress * (float)time.TotalHours);
        mMintuesPivot.localRotation = Quaternion.Euler(0f, 0f, cMintuesToDegrees * (float)time.TotalMinutes);
        mSecondsPivot.localRotation = Quaternion.Euler(0f, 0f, cSecondsToDegrees * (float)time.TotalSeconds);
    }

    [SerializeField]
    private Transform mHoursPivot, mMintuesPivot, mSecondsPivot;
}
