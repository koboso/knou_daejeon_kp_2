using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    private Logic logic;
    private Text text;

    void Start()
    {
        //로직 가져옴
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        text = transform.Find("Text").GetComponent<Text>();
    }

    public void TogglePause()
    {
        if (logic.state == Logic.GameState.PLAY)
        {
            logic.state = Logic.GameState.PAUSE;
            text.text = "PLAY";
        }
        else if (logic.state == Logic.GameState.PAUSE)
        {
            logic.state = Logic.GameState.PLAY;
            text.text = "STOP";
        }
    }
  }
