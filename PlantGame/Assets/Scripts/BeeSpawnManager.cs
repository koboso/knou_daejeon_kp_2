using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawnManager : MonoBehaviour
{
    private Logic logic = null;

    public float spawnTime;
    public Transform[] spawnPoints;
    public GameObject bee;

    private void Start()
    {
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        spawnTime = 5f;
    }

    private void Update()
    {
        if(logic)
        {
            if (logic.state != Logic.GameState.PLAY)
            {
                spawnTime = 5f;
                return;
            }
        }

        if (0 >= spawnTime)
        {
            //벌 스폰포인트 인덱스가 될 랜덤한 수 
            int x = Random.Range(0,spawnPoints.Length);
            //랜덤 인덱스에 해당하는 스폰포인트에서 벌 생성
            SpawnBee(x);
        }
        spawnTime -= Time.deltaTime;
    }

    //벌 생성하는 함수
    public void SpawnBee(int ranNum)
    {
        //스폰타이머 리셋
         spawnTime = logic.BeeSpawnTime;
         Debug.Log("다음 벌은 " + spawnTime + "초");
        //랜덤 인덱스에 해당하는 스폰포인트에서 벌 생성
         Instantiate(bee, spawnPoints[ranNum]);

    }
}
