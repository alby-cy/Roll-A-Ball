using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float curTime;
    private bool isTiming;
    private float minutes;
    private float seconds;
    private string clockTime;

    public void StartTimer() { isTiming = true; }
    public void EndTimer() { isTiming = false; }

    public float GetTime() { return curTime; }
    public string GetClock() { return clockTime; }

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            curTime += Time.deltaTime;
            //calculate minutes and seconds
            minutes = Mathf.FloorToInt(curTime/60);
            seconds = Mathf.FloorToInt(curTime%60);
            //display clockTime as MM:SS where M=Minutes and S=Seconds
            clockTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
