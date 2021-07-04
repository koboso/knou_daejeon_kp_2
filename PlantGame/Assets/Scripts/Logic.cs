using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour{
    // Game State 
    public enum GameState {READY = 0, PLAY, CLEAR, GAMEOVER, PAUSE };
    public GameState state = GameState.PLAY;

    public float growthSpeed = 0.003f;      // 프레임당 성장 속도
    public float clickGrowthSpeed = 0.2f;   // 클릭시 성장 속도
    public float treeHeight = 0f;
    public int beesKilled = 0;

    /**
     * 게임확률 계산공식
     */

    // 잎에서 꽃이 필 확률 계산.
    public bool BloomFlower
    {   get { return Random.Range(0f, treeHeight + 20) < treeHeight; }}

    // 여왕벌 생성 확률
    public bool QueenBee
    {   get { return Random.Range(0, 31) == 1;  }}

    // 벌 속도 계산
    public float BeeSpeed
    {   get { return Random.Range(0.3f, 1.2f);  }}

    // 벌 피통
    public int BeeHP
    {
        get { return 1; }
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

    public void BeeKilled()
    {
        this.beesKilled++;
    }

    public void setHeight(float height)
    {
        this.treeHeight = height;
    }

    // 생성한 객체 모두 지워주는 함수.
    public void InitScore(){
        treeHeight = 0;
        beesKilled = 0;
    }

}
