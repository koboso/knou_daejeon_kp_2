using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 시작할 때 사용되는 화면
public class GameOnScreen : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true); // 
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
