using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour{
    private bool isMaxSized = false;
    private Logic logic = null;


    void Start(){
        this.logic=GameObject.Find("GameManager").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update(){
        if (logic==null){
            Debug.Log("로직이 없습니다.");
            return;
        }

        if (isMaxSized){
            // 최대 사이즈 까지 자랐으니, 더이상 업데이트 문 돌지 않도록 예외처리.
            return;
        }

        switch (logic.state)
        {
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

    //식물이 자라도록 해주는 함수.
    public bool GrowPlant(){
        if (isMaxSized) return true;

        return false;

    }


}
