using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float curTime;
    private bool isTiming;

    public void StartTimer() { isTiming = true; }
    public void EndTimer() { isTiming = false; }

    public float GetTime() { return curTime; }

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            curTime += Time.deltaTime;
        }
    }
}
