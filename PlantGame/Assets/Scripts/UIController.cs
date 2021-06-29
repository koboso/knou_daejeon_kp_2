using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject logicObject;
    private Logic logic = null;

    void Start() {
        // 로직 정보를 가져오기위함.
        logic=logicObject.GetComponent<Logic>();

    }

    void Update() {
        switch (logic.state){
            case Logic.GameState.READY:
                // 준비 상태의 UI처리
                break;
            case Logic.GameState.PLAY:
                // 플레이 상태의 UI 처리
                break;
            case Logic.GameState.PAUSE:
                // 멈춤 상태의 UI처리
                break;
            case Logic.GameState.GAMEOVER:
                // 게임 오버 상태의 UI처리
                break;

            case Logic.GameState.CLEAR:
                // 클리어 상태의 UI처리
                break;
        }
        
    }
}
