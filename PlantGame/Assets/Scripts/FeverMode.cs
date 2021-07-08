using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverMode : MonoBehaviour
{
    private Logic logic = null;
    [SerializeField]
    private Slider feverbar;

    private bool isInit = true;

    public float fevertime = 5f;

    private int maxFever = 10;

    // Start is called before the first frame update
    void Start()
    {
        //로직 가져옴
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();

        HandleFever();
    }

    // Update is called once per frame
    void Update()
    {
        switch (logic.state)
        {
            case Logic.GameState.READY:
                if (isInit)
                    InitFever();
                break;
            case Logic.GameState.PLAY:
                FeverUpdate();
                break;
            case Logic.GameState.FEVER:
                FeverTime();
                break;
            case Logic.GameState.PAUSE:
                break;
            case Logic.GameState.GAMEOVER:
                isInit = true;
                break;
            case Logic.GameState.CLEAR:
                break;
        }

    }

    private void InitFever()
    {
        logic.feverpoint = 0;

        fevertime = 5f;
        HandleFever();

        isInit = false;
    }

    // 피버 모드에 업데이트 하는 로직
    private void FeverUpdate()
    {
        if (logic.feverpoint >= maxFever)
            logic.FeverTime();

        HandleFever();
    }

    private void FeverTime()
    {
        fevertime -= Time.deltaTime;

        if (fevertime < 0)
        {
            Debug.Log("피버타임 끝");
            maxFever += 4;
            InitFever();
            logic.FeverEnd();
        }
    }

    private void HandleFever()
    {
        feverbar.maxValue = maxFever;
        feverbar.value = logic.feverpoint;
    }
}
