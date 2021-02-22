using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public bool isSlowDown = false;

    void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
    }
}
