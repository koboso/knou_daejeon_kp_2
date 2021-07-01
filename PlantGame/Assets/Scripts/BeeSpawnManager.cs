using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawnManager : MonoBehaviour
{

    public float spwanTime = 3f;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject bee;

    private void Update()
    {
        if(curTime >= spwanTime)
        {
            //벌 스폰포인트 인덱스가 될 랜덤한 수 
            int x = Random.Range(0,spawnPoints.Length);
            //랜덤 인덱스에 해당하는 스폰포인트에서 벌 생성
            SpawnBee(x);
        }
        curTime += Time.deltaTime;
    }

    //벌 생성하는 함수
    public void SpawnBee(int ranNum)
    {
        //스폰타이머 리셋
        curTime = 0;
        //랜덤 인덱스에 해당하는 스폰포인트에서 벌 생성
        Instantiate(bee,spawnPoints[ranNum]);
    }
}
