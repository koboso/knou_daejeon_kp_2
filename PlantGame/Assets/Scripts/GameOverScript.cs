using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 종료
public class GameOverScript : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("애플리케이션을 종료합니다.");
        Application.Quit();
    }
}
