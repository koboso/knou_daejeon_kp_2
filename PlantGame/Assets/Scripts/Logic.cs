using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 게임의 난이도, 확률, 점수 등을 위한 로직
public class Logic : MonoBehaviour{
    // Game State 
    public enum GameState {READY = 0, PLAY, FEVER, CLEAR, GAMEOVER, PAUSE };
    public GameState state = GameState.READY;

    public float growthSpeed = 0.003f;      // 프레임당 성장 속도 (프레임당)
    public float clickGrowthSpeed = 0.2f;   // 클릭시 성장 속도 (클릭당)
    public float feverGrowthSpeed = 0.012f; // 피버 성장속도 (프레임당)
    public float treeHeight = 0f;
    public int beesKilled = 0;
    public int feverpoint = 0;
    public AudioSource feverSound;

    /**
     * 게임확률 계산공식
     */

    // 잎에서 꽃이 필 확률 계산.
    public bool BloomFlower
    {   get { return Random.Range(0f, treeHeight + 20) < treeHeight; }}

    // 여왕벌 생성 확률 - 20마리 잡을때마다 확률이 커짐
    public bool QueenBee
    {   get { return Random.Range(0, 31 - beesKilled / 20) == 0;  }}

    // 벌 날아가는 속도 - 숫자가 클 수록 빠름
    public float BeeSpeed
    {   get {
            float factor = (float)beesKilled / 300 + 1;
            return Random.Range(0.3f, 1.2f) * factor;  }}

    // 벌 생성되는 시간 - 길수록 늦게 생성됨, 최고 0.5초 단위
    public float BeeSpawnTime
    {
        get { return 4f - Mathf.Min(3.8f, Random.Range((float)beesKilled/10, (float)(beesKilled+5)) / 5); }
    }
    // 벌 피통
    public int BeeHP
    {
        get { return 1; }
    }

    public void BeeKilled() // 벌 잡을때마다
    {
        this.beesKilled++;
    }

    // Fever 수치 증가
    public void FeverUp(int damage)
    {
        this.feverpoint++;
    }

    // FeverTime 게임모드 전환
    public void FeverTime()
    {
        feverSound.Play();
        state = GameState.FEVER;
    }

    public void FeverEnd()
    {
        feverSound.Stop();
        state = GameState.PLAY;
        feverpoint = 0;
    }

    // 나무 키 계산은 PlantSpawnManager 에서 한다
    public void SetHeight(float height)
    {
        this.treeHeight = height;
    }

    // 생성한 객체 모두 지워주는 함수.
    public void InitScore(){
        treeHeight = 0;
        beesKilled = 0;
    }

    // 스타트일때 피버포인트 초기화
    public void GameReady()
    {
        state = GameState.READY;
        feverpoint = 0;
        InitScore();
    }
}
