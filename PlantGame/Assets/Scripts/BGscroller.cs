using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배경 돌아가는 스크롤러
public class BGscroller : MonoBehaviour
{
    private MeshRenderer render;

    Logic logic;

    public float speed;//회전 속도
    private float offset;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
    }

    void Update()
    {
        if (this.tag == "ingame")//오브젝트 태그가 인게임인지 확인
        {
            //게임상태가 플레이중이거나 피버상태일 때
            if (logic.state == Logic.GameState.PLAY || logic.state == Logic.GameState.FEVER)
            {
                offset += Time.deltaTime * speed;//시간, 지정 속도 기반으로 얼만큼 이동할지
                render.material.mainTextureOffset = new Vector2(offset, 0);//텍스쳐를 이동
            }
        }
        else
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
