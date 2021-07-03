using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBee : MonoBehaviour
{
    public int hp = 1;
    private float speed = 1f;
    // 처음 생성되는 포지션.
    public Vector3 spawnpos;
    //마우스 클릭 시 선택된 오브젝트
    private GameObject target;
    //여왕벌 스폰 시 변경할 색
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spawnpos = this.gameObject.transform.position;//초반 생성좌표
        speed = Random.Range(0.3f, 1.2f);//벌 속도를 랜덤하게
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Random.Range(0, 31) == 1)//30분의 1 확률로 사이즈, 피통 크고 색 다른 여왕벌 생성
        {
            Debug.Log("여왕벌");
            transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
            spriteRenderer.color = color;
            hp = 5;
            speed = 0.5f;
        }
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
            if (Input.GetMouseButtonDown(0))//마우스 클릭 시
            {
                CastRay();//마우스 클릭 좌표에 있는 오브젝트 가져와서
                if (target == this.gameObject)//Bee라면
                {
                    TakeDamage(1);//피 1 감산
                }
            }
        }
    }
    //지정한 정수의 데미지를 hp에서 감산
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }

    //마우스 클릭 시 좌표 받아서 타겟에 클릭된 좌표의 게임오브젝트를 저장
    public void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target = hit.collider.gameObject;
        }
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