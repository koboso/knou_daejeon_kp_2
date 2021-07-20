using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReStartGame : MonoBehaviour
{
    private Logic logic;
    private Button thisbutton;
    private void Start()
    {
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        thisbutton = GetComponent<Button>();
    }

    //게임오버화면이 아닌 리스타트버튼은 게임오버화면에서 작동 불가
    private void Update()
    {
        if (gameObject.transform.parent.name != "GameOverScreen")
        {
            if (logic.state == Logic.GameState.GAMEOVER)
            { thisbutton.interactable = false; }
            else thisbutton.interactable = true;
        }
    }

    // 리스타트 버튼 클릭시 실행되는 코드.
    public void NewGame()
    {
        logic.GameReady(); // 피버포인트 초기화
        //transform.parent.GetComponent<GameOverScreen>().Hide();
        if (gameObject.transform.parent.name == "GameOverScreen")
        { transform.parent.GetComponent<GameOverScreen>().Hide(); }
    }

}
