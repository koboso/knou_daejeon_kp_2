using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start 화면의 메인메뉴 옵션
public class MainMenuOption : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("애플리케이션을 종료합니다.");
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(1);
    }
}
