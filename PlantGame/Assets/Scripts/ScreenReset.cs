using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 화면 해상도 고정
public class ScreenReset : MonoBehaviour
{

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(480, 800, true);
    }
}
