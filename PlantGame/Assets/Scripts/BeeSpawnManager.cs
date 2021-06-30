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
            int x = Random.Range(0,spawnPoints.Length);
            SpawnBee(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnBee(int ranNum)
    {
        curTime = 0;
        Instantiate(bee,spawnPoints[ranNum]);
    }
}
