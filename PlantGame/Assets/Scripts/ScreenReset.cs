using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReset : MonoBehaviour
{

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(480, 800, true);
    }
}
