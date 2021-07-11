using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


// 게임이 종료 되었을 때 사용하는 화면
public class GameOverScreen : MonoBehaviour
{
    public Text treeHeight;
    public Text beesKilled;
    public Text highScoreText;
 

    private float allTimeHighScore;
    private string allTimeHighDate;
    private float todayHighScore;
    private string todayHighDate;
    private string today;

    public void Setup(float score, int bee)
    {
        gameObject.SetActive(true);

        if (todayHighScore < score ) // 하루 최고점 기록
        {
            todayHighScore = score;
            todayHighDate = today;
            highScoreText.text = "TODAY'S BEST !!";

            if(allTimeHighScore < score)  // 지금까지의 최고점 기록
            {
                allTimeHighScore = score;
                allTimeHighDate = today;
                highScoreText.text = "ALLTIME BEST !!";
                
            }
            SaveScore();
        }
        else
        {
            highScoreText.text = "Today's High: " + 
                string.Format("{0:N2}",PlayerPrefs.GetFloat("TodayHighScore")) + " m";
        }
        treeHeight.text = "\nTree is grown " + string.Format("{0:N2}", score) + " m";
        beesKilled.text = "\nBees Killed: " + bee;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // 하루(Today)와 지금까지의 최고점수 
    void Awake()
    {
        DateTime dt = DateTime.Now;  
        today = dt.ToString("yyyy-MM-dd"); // 오늘 날짜를 문자화

        allTimeHighScore = PlayerPrefs.GetFloat("AllTimeHighScore");
        allTimeHighDate = PlayerPrefs.GetString("AllTimeHighDate");
        todayHighScore = PlayerPrefs.GetFloat("TodayHighScore");
        todayHighDate = PlayerPrefs.GetString("TodayHighDate");

        if (todayHighDate != today)
        {
            todayHighDate = today;
            todayHighScore = 0;
        }
    }

    // 점수와 날짜 저장
    void SaveScore()
    {
        PlayerPrefs.SetFloat("AllTimeHighScore", allTimeHighScore);
        PlayerPrefs.SetString("AllTimeHighDate", allTimeHighDate);
        PlayerPrefs.SetFloat("TodayHighScore", todayHighScore);
        PlayerPrefs.SetString("TodayHighDate", todayHighDate);
        PlayerPrefs.Save();
    }

    // 점수와 날짜 리셋
    public void ResetScore()
    {
        allTimeHighDate = "";
        allTimeHighScore = 0f;
        todayHighDate = "";
        todayHighScore = 0f;
        SaveScore();
    }
}
