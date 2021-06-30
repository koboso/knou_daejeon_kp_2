using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {
    // 벌의 상태값을 가지고 있음.
    public SpriteRenderer render;
    Logic logic = null;



    public enum State { NONE, INIT, SPAWN, MOVE, DEAD };
    public State state = State.NONE;

    // 체력게이지
    private int Hp = 0;
    // 속도.
    private float speed = 0f;
    // 처음 생성되는 포지션.
    private Vector3 spawnPos = Vector3.zero;

    private Vector3 targetPosition = Vector3.zero;



    // 벌이 죽었는지 체크하는 변수.
    private bool isDead = false;

    // 여왕벌 인지 체크하는 변수.
    private bool isQueen = false;

    // 만약 여왕벌이라면 해당 함수를 불러서 사용.
    public void SetQueenBee(int hp) {
        this.isQueen=true;
        this.Hp=hp;
    }

    public bool IsBeeDead {
        get {
            return this.isDead;
        }
    }
    // 벌이 죽었을때 아래 함수를 호출.
    public void BeeIsDead() {
        if (this.isDead) return;
        this.isDead=true;
    }

    // 초기화 함수.
    public void Init() {
        // 로직 정보를 가져옴.
        logic=GameObject.Find("GameManager").GetComponent<Logic>();
        this.GetComponent<SpriteRenderer>().sprite= render.sprite;
    }

    private void Update() {
        if (IsBeeDead) return;

        switch (state){
            case State.NONE:
                state=State.INIT;
                break;

            case State.INIT:
                Init();
                state=State.SPAWN;
                break;

            case State.SPAWN: 
                break;

            case State.MOVE:
                //Fly();
                break;

            case State.DEAD: BeeIsDead(); break;
        }

    }

    // 벌이 처음 이동하는것.
    // 벌이 생성된 위치에서 꽃 방향



    private void Fly() {
        if(this.spawnPos.x <0){
            // 왼쪽 에서 벌이 생성된경우.

        }
        else{
            // 오른쪽에서 벌이 생성된경우
        }
        
    }


    public void SetTargetPosition(Vector3 pos){

        if (this.logic==null){
            Debug.Log("로직 이 없습니다.\n");
            return;
        }

        state=State.MOVE;
        this.targetPosition=pos;
    }


}
