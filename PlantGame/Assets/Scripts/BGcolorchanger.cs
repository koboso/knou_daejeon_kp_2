using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//배경색 나무 높이, HSV기반으로 변경
public class BGcolorchanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public enum BGState { DAY = 0, NIGHT };//HSV기반 V값 기준으로 밤, 낮 상태 구분
    public BGState state = BGState.DAY;//기본 낮
    private float offset = 1f;//HSV에서 v값이 될 값
    private float speed = 0.0025f;//색 변화속도
    private Logic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();//로직값 가져옴

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void BGLogic()
    {
        switch (state)//밤, 낮 상태
        {
            case BGState.DAY:
                break;
            case BGState.NIGHT:
                break;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        BGLogic();
        if (this.tag == "ingame")//배경 태그가 인게임
        {
            //게임상태가 플레이중일 때
            if (GameObject.Find("GameManager").GetComponent<Logic>().state == Logic.GameState.PLAY)
            {
                if (state == BGState.DAY)//낮상태일 땐
                {
                    offset -= speed * logic.treeHeight / 1000;//V값 낮춤 == 어두워짐
                    spriteRenderer.color = Color.HSVToRGB(1, 0, offset);
                    if (offset < 0.3)//V값이 0.3 아래로 떨어지면
                    {
                        Debug.Log("밤이 됩니다");//상태 밤으로 바꾸고 밤 색변화 적용
                        state = BGState.NIGHT;
                        offset += speed * logic.treeHeight / 1000;
                    }
                }
                else//밤 상태일 땐
                {
                    offset += speed * logic.treeHeight / 1000;//V값 높임 == 밝아짐
                    spriteRenderer.color = Color.HSVToRGB(1, 0, offset);
                    if (offset > 1)//최대값으로 올라가면
                    {
                        Debug.Log("낮이 됩니다");//상태 낮으로 변경 후 낮 색변화 적용
                        state = BGState.DAY;
                        offset -= speed * logic.treeHeight / 1000;
                    }
                }


            }
            //게임 상태가 준비중으로 돌아가면 초기화
            else if (GameObject.Find("GameManager").GetComponent<Logic>().state == Logic.GameState.READY)
            {
                spriteRenderer.color = Color.HSVToRGB(1, 0, 1);
                offset = 1f;
            }
        }
    }
}
