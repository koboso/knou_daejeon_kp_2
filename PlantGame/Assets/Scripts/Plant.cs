﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour{
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private enum PlantState {
        START = 0,
        HGROW,
        LGROW,
        GROWN
    };

    private enum GrowthType
    {
        NORMAL = 0,
        CLICK = 1
    };
    private PlantState state = PlantState.START;

    private Logic logic = null;
    private PlantSpawnManager psm = null;   // 다 크면 부모한테 알리기 위해

    public float plantHeight = 0f;          // 현재 키
    public float extraGrowth = 0f;          // 추가로 옆으로 더 크는 양
    public Vector3 Height
    {
        get { return plantHeight * endScale;  }
    }

    // 시작 스케일에서 키성장 종료 스케일까지
    private Vector3 initScale;
    private Vector3 endScale;
    
    // 다 컸을때 옆으로 더 크는 양
    private Vector3 extraGrowthScale;

    // 꽃 관련 변수
    private GameObject flowerPrefab = null;
    private bool isFlowerBloom = false;
 
    //충돌 시 지정 색상으로 변화
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = color;

    }

    void Start(){
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        psm = transform.parent.GetComponent<PlantSpawnManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        RandomFlipX(gameObject);

        // 꽃을 피울건지 여부 - 이 부분은 PlantSpawn으로 옮겨야 하지 않을까?
        if (Random.Range(0f, logic.treeHeight) > 2)
        {
            flowerPrefab = Resources.Load("Prefabs/FlowerPrefab") as GameObject;
        }

        initScale = new Vector3(10f, 10f, 1.0f);  // 안큰거
        endScale = new Vector3(50f, 50f, 1.0f);   // 다 큰거

        extraGrowthScale = new Vector3(25f, 0.0f, 0f); // 옆으로 더 클 양
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
                if (Input.GetMouseButtonUp(0))
                    GrowPlant(GrowthType.CLICK);
                else
                    GrowPlant(GrowthType.NORMAL);

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
    private bool GrowPlant(GrowthType gt){
        switch(state)
        {
            case PlantState.GROWN:
                return true;

            case PlantState.START:
            case PlantState.HGROW:  // 부피성장단계
                if (gt == GrowthType.NORMAL)
                    plantHeight += logic.growthSpeed;
                else
                {   // GrowthType.CLICK
                    plantHeight += logic.clickGrowthSpeed;
                }

                if (plantHeight >= 1.0f)
                {
                    plantHeight = 1.0f;
                    Debug.Log("다 자랐습니다.");
                    state = PlantState.LGROW;

                    // 위로 다 컸으면, 새 플랜트를 만든다.
                    psm.CreatePlant();
                }

                // 연속적으로 성장하기 위한 Scale 값을 계산
                transform.localScale = Vector3.Slerp(initScale, endScale, plantHeight);

                break;
            case PlantState.LGROW:  // 폭 성장단계 Lateral Growth
                extraGrowth += logic.growthSpeed / 3;       // 1/3 속도로 성장
                if(extraGrowth >= 1)
                {
                    extraGrowth = 1f;
                    state = PlantState.GROWN;
                    Debug.Log("옆으로 다 자랐습니다.");
                }
                transform.localScale = endScale + extraGrowthScale * extraGrowth;

                // 꽃 프리팹이 설정되고 아직 피지 않았으면 꽃을 피운다.
                if (flowerPrefab && !isFlowerBloom)
                    FlowerBloom();

                break;
        }

        return false;
    }

    void RandomFlipX(GameObject g)
    {
        if (Random.Range(0, 2) == 1)
            g.GetComponent<SpriteRenderer>().flipX = true;
    }

    void FlowerBloom()
    {
        GameObject p = Instantiate(flowerPrefab, transform);

        RandomFlipX(p);
        p.transform.position += new Vector3(Random.Range(-40f, 40f)+ Random.Range(-40f, 40f), 0, 0);
        isFlowerBloom = true;
    }

}
