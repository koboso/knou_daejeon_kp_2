using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartGame : MonoBehaviour
{

    // 리스타트 버튼 클릭시 실행되는 코드.
    public void NewGame()
    {
        GameObject.Find("GameManager").GetComponent<Logic>().state = Logic.GameState.READY;
        //transform.parent.GetComponent<GameOverScreen>().Hide();
        if(gameObject.transform.parent.name == "GameOverScreen")
        { transform.parent.GetComponent<GameOverScreen>().Hide(); }
    }

}
