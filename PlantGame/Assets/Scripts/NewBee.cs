using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBee : MonoBehaviour
{
    private Logic logic;

    private AudioSource queenSound;
    private AudioSource beekilledSound;

    public int StartHealth;  // HealthBar
    public Image HealthBar;

    private int maxHp = 1;
    public int hp = 1;
    private float speed = 1f;

    // 처음 생성되는 포지션.
    private Vector3 initPos;
    private Vector3 dir = Vector3.left;

    //마우스 클릭 시 선택된 오브젝트
    private GameObject target;
    //여왕벌 스폰 시 변경할 색
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        queenSound = GameObject.Find("QueenSound").GetComponent<AudioSource>();
        beekilledSound = GameObject.Find("BeeKilled").GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        initPos = transform.position;//초반 생성좌표

        // 왼쪽 에서 벌이 생성된경우. 방향 바꾸고 오른쪽으로 이동
        if (initPos.x < 0.00f)
        {
            spriteRenderer.flipX = true;
            dir = Vector3.right;
        }

        if (logic) {
            speed = logic.BeeSpeed;//벌 속도를 랜덤하게
            hp = logic.BeeHP;       // 레벨별 HP 다르게 하려면 logic에서 가져오기

            if (logic.QueenBee)//30분의 1 확률로 사이즈, 피통 크고 색 다른 여왕벌 생성
            {
                queenSound.Play(); //여왕벌 나오면 Audio Play

                Debug.Log("여왕벌");
                gameObject.name = "QueenBee";
                transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
                spriteRenderer.color = color;
                maxHp = hp = 5;
                speed = 0.5f;
                //
                //StartHealth = hp;  // HealthBar
            }
        }

        speed *= 0.02f;
    }

    private void Update()
    {
        if (logic)
            switch (logic.state)
            {
                case Logic.GameState.READY:
                    Destroy(gameObject);
                    break;
                case Logic.GameState.PLAY:
                    UpdateBee();
                    break;
                case Logic.GameState.FEVER:
                    FeverKill();
                    break;
                case Logic.GameState.CLEAR:
                    break;
                case Logic.GameState.PAUSE:
                    break;
                case Logic.GameState.GAMEOVER:
                    break;
            }
        else UpdateBee();
    }

    private void UpdateBee()
    {
        if (hp <= 0)//피 0 이하 되면 제거
        {
            if (this.name == "QueenBee")
            {
                queenSound.Stop();
                logic.FeverUp(3);
            }    
            else
                logic.FeverUp(1);

            beekilledSound.Play(); //벌 죽을때 Audio Play
            logic.BeeKilled();
            Destroy(gameObject);
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

    private void FeverKill()
    {
        Destroy(gameObject);
    }

    //지정한 정수의 데미지를 hp에서 감산
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        HealthBar.fillAmount = (float)hp/maxHp; // HealthBar
    }

    //마우스 클릭 시 좌표 받아서 타겟에 클릭된 좌표의 게임오브젝트를 저장
    public void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            target = hit.collider.gameObject;
        }
    }

    //벌 움직이는 함수
    private void Fly()
    {
        transform.localPosition += dir * speed * Time.deltaTime;

        // 화면 범위를 넘어가면 벌을 없앰.
        if (Mathf.Abs(transform.localPosition.x) > 0.17f)
        {
 //           Debug.Log("벌 이탈 x=" + transform.localPosition);
            Destroy(gameObject);
        }
    }
}