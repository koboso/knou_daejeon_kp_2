using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBee : MonoBehaviour
{
    public int hp = 1;
    private float speed = 1f;
    // 처음 생성되는 포지션.
    public Vector3 spawnpos;
    private void Start()
    {
        spawnpos = this.gameObject.transform.position;
    }


    private void Update()
    {
        if (hp <= 0)//피 0 이하 되면 제거
        {
            Destroy(this.gameObject);
        }
        else
        {
            Fly();
        }
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }

    //벌 움직이는 함수
    private void Fly()
    {
        if (spawnpos.x < 0.00)
        {
            // 왼쪽 에서 벌이 생성된경우. 방향 바꾸고 오른쪽으로 이동
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            //오른쪽에서 벌이 생성 된 경우. 왼쪽으로 이동
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }
}