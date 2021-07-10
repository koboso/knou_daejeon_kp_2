using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 게임이 종료 되었을 때 사용하는 화면
public class GameOverScreen : MonoBehaviour
{
    public Text treeHeight;
    public Text beesKilled;
    public Text highScoreText;

    public float highScore ; // 최고점 -----

    public void Setup(float score, int bee)
    {
        gameObject.SetActive(true);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            highScoreText.text = "NEW HIGHSCORE !!";
        }
        else
        {
            highScoreText.text = "High Score: " + 
                string.Format("{0:N2}",PlayerPrefs.GetFloat("HighScore")) + " m";
        }

        treeHeight.text = "\nTree is grown " + string.Format("{0:N2}", score) + " m";
        beesKilled.text = "\nBees Killed: " + bee;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");

    }
}
