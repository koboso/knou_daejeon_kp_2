using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour{
    private enum PlantState {
        START = 0,
        HGROW,
        LGROW,
        GROWN
    };
    private PlantState state = PlantState.START;

    private Logic logic = null;
    private PlantSpawnManager psm = null;

    public float growthSpeed = 0.01f;
    public float plantHeight = 0f;
    public float extraGrowth = 0f;

    private Vector3 initScale;
    private Vector3 endScale;
    private Vector3 deltaScale;
    private Vector3 extraGrowthScale;

    void Start(){
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
        psm = GameObject.Find("PlantTree").GetComponent<PlantSpawnManager>();

        initScale = new Vector3(0.2f, 0.2f, 1.0f);
        endScale = new Vector3(1.0f, 1.0f, 1.0f);

        deltaScale = endScale - initScale;

        extraGrowthScale = new Vector3(0.5f, 0.0f, 0f);
    }

    // Update is called once per frame
    void Update(){
        if (logic==null){
            Debug.Log("로직이 없습니다.");
            return;
        }

        if (state == PlantState.GROWN){
            // 최대 사이즈 까지 자랐으니, 더이상 업데이트 문 돌지 않도록 예외처리.
            return;
        }


        switch (logic.state)
        {
            case Logic.GameState.READY:
                // 준비 상태의 UI처리
                break;
            case Logic.GameState.PLAY:
                GrowPlant();

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
        switch(state)
        {
            case PlantState.GROWN:
                return true;

            case PlantState.START:
            case PlantState.HGROW:
                plantHeight += growthSpeed;

                if (plantHeight >= 1.0f)
                {
                    plantHeight = 1.0f;
                    Debug.Log("다 자랐습니다.");
                    state = PlantState.LGROW;

                    psm.CreatePlant();
                }
                transform.localScale = Vector3.Slerp(initScale, endScale, plantHeight);

                break;
            case PlantState.LGROW:
                extraGrowth += growthSpeed / 3;
                if(extraGrowth >= 1)
                {
                    state = PlantState.GROWN;
                    Debug.Log("옆으로 다 자랐습니다.");
                }
                transform.localScale = endScale + extraGrowthScale * extraGrowth;
                break;
        }

        // initScale + deltaScale * plantHeight
        //    + extraGrowthScale * extraGrowth;

        return false;
    }

}
