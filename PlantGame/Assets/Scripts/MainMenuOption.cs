using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start 화면의 메인메뉴 옵션
public class MainMenuOption : MonoBehaviour
{
    public void playgame()  // 플레이 스크린으로 이동
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("애플리케이션을 종료합니다.");
        Application.Quit();
    }

    public void GoMenu() // 메뉴 스크린으로 이동
    {
        SceneManager.LoadScene(1);
    }

    public void Score() // 스코어보드로 이동
    {
        SceneManager.LoadScene(3);

    }
}
