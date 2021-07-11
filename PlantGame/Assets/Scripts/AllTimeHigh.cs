using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 지금까지의 기록 중 최고 점수와 날짜 저장 및 리셋

public class AllTimeHigh : MonoBehaviour
{
    public Text alltimeHighScoreText;
    public Text alltimeHighDateText;

    private float allTimeHighScore;
    private string allTimeHighDate;
    private float todayHighScore;
    private string todayHighDate;
    private string today;

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
        SetScore();
    }

    // 점수와 날짜 출력
    void SetScore()
    {
        alltimeHighScoreText.text = "Score: " +
            string.Format("{0:N2}", PlayerPrefs.GetFloat("AllTimeHighScore")) + " m";
        alltimeHighDateText.text = "Date: " +
            string.Format("{0:N2}", PlayerPrefs.GetString("AllTimeHighDate"));
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
        SetScore();
    }
}
