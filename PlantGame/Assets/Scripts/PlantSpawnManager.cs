using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawnManager : MonoBehaviour {
    Logic logic = null;
    UIController ui = null;
    List<GameObject> plantList;
    private Plant topPlant = null;
 
    bool isInit = false;
    int indexHead = 0;
    int indexTail = 0;

    private Vector3 initPosition;

    void Start() {
        isInit=false;

        plantList=new List<GameObject>();

        logic=GameObject.Find("GameManager").GetComponent<Logic>();
        ui = GameObject.Find("UICanvas").GetComponent<UIController>();

        initPosition = transform.position;

        ReadyPlant();
 
    }

    // 모든 영역 초기화
    private void ReadyPlant() {
        if (isInit) return;
        // 동적 생성된 식물 리스트 삭제.
        for (int i = indexTail; i < indexHead; i++) {
            Destroy(plantList[i]);
        }
        plantList.Clear();
        isInit=true;
        indexTail = indexHead = 0;
        logic.setHeight(0f);
      
        transform.position = initPosition;      // 위치도 초기화

        CreatePlant();
    }


    void Update() {

        if (logic==null) return;

        if (logic.state==Logic.GameState.READY) {
            ReadyPlant();
        }
        if (logic.state!=Logic.GameState.PLAY) return;

        // 나무 전체가 아래로 이동
        float height = indexHead - 1 + topPlant.plantHeight;
        transform.position = initPosition + new Vector3(0f, -height * 50, 0f);

        logic.setHeight(height);

        isInit = false;
    }

    public void CreatePlant() {
        GameObject p = Instantiate(Resources.Load("Prefabs/BabyPlant") as GameObject, transform);

        plantList.Add(p);
        topPlant = p.GetComponent<Plant>() as Plant;

        p.name = "Plant-" + indexHead;
        p.transform.position += new Vector3(0.0f, (float)indexHead*50, 0.0f);

        indexHead++;

        if (plantList.Count > 15)    // 플랜트가 열 다섯개 넘으면 맨 오래된 플랜트를 지움
        {
            Destroy(plantList[indexTail]);
            indexTail++;
        }
        for (int i = indexTail; i < indexHead; i++)
        {
            plantList[i].GetComponent<SpriteRenderer>().sortingOrder = 20-(i-indexTail);
        }

        // 테스트용
        if (indexHead > 20)
            logic.state = Logic.GameState.GAMEOVER;

        ui.DisplayFloatingText("New Bud!");
    }

}
