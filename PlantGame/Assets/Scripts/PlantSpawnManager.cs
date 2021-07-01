using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawnManager : MonoBehaviour {
    Logic logic = null;
    List<GameObject> plantList;
    private Plant topPlant = null;

    bool isInit = false;
    int indexHead = 0;
    int indexTail = 0;

    enum PlantState {
        READY = 0, CREATE = 1, GROW, WAIT,
    }

    PlantState plantState = PlantState.READY;

    private Vector3 initPosition;

    void Start() {
        isInit=false;

        plantList=new List<GameObject>();
        logic=GameObject.Find("GameManager").GetComponent<Logic>();

        CreatePlant();
        initPosition = transform.position;
    }

    private void ClearPlant() {
        if (isInit) return;
        // 동적 생성된 식물 리스트 삭제.
        for (int i = 0; i<plantList.Count; i++) {
            Destroy(plantList[i]);
        }
        plantList.Clear();
        isInit=true;
        indexHead=0;
        plantState=PlantState.READY;
    }

    void Update() {
        if (logic==null) return;

        if (logic.state==Logic.GameState.GAMEOVER||logic.state==Logic.GameState.CLEAR) {
            plantState=PlantState.READY;
        }
        if (logic.state!=Logic.GameState.PLAY) return;

//        GameObject plant = plantList[indexHead - 1];

        transform.position = initPosition 
            + new Vector3(0f, - indexHead + 1 - topPlant.plantHeight, 0f);

        isInit = false;
    }

    public void CreatePlant() {
        GameObject p = Instantiate(Resources.Load("Prefabs/BabyPlant") as GameObject, transform);
        plantList.Add(p);
        topPlant = p.GetComponent<Plant>() as Plant;

        p.name = "Plant-" + indexHead;
        p.transform.position += new Vector3(0.0f, 1.0f, 0.0f) * indexHead;

        indexHead++;
        plantState = PlantState.GROW;
    }

    /*
    // 꽃이 자라는곳
    void GrowPlant()
    {
        // 최대 사이즈로 자라났다면. 새로운 식물을 생성하도록.
       if(plantList[index].GetComponent<Plant>().GrowPlant())
        {
            plantState=PlantState.CREATE;
            CreatePlant();
        }

    }
    */
}
