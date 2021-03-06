using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Pause/Stop 토글 버튼
public class PauseButton : MonoBehaviour
{
    private Logic logic;
    private Text text;

    void Start()
    {
        //로직 가져옴
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        text = transform.Find("Text").GetComponent<Text>();
        text.text = "STOP";
    }

    //STOP, PLAY 텍스트 변환
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
