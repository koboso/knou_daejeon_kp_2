﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour{
    // Game State 
    public enum GameState {READY = 0, PLAY, CLEAR, GAMEOVER, PAUSE };
    public GameState state = GameState.PLAY;

    public UIController ui = null;

    public float growthSpeed = 0.01f;       // 프레임당 성장 속도
    public float clickGrowthSpeed = 0.2f;   // 클릭시 성장 속도
    public float treeHeight = 0f;
    public int beesKilled = 0;


    void Start(){
//        ui = gameObject.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update(){
        GameLogic();
    }

    public void GameLogic()
    {
        switch (state)
        {
            case GameState.READY:
                break;
            case GameState.PLAY:
                break;
            case GameState.CLEAR:
                break;
            case GameState.PAUSE:
                break;
            case GameState.GAMEOVER:
                break;
        }

    }


    public void setHeight(float height)
    {
    //    Debug.Log("setHeight = " + height);
        this.treeHeight = height;
        if (ui) ui.DisplayScoreLine();
    }

    // 생성한 객체 모두 지워주는 함수.
    void ClearInit(){

    }


}
