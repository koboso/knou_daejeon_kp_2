using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


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
        DateTime dt = DateTime.Now;  // 
        today = dt.ToString("yyyy-MM-dd");

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


    void SetScore()
    {
        alltimeHighScoreText.text = "Score: " +
            string.Format("{0:N2}", PlayerPrefs.GetFloat("AllTimeHighScore")) + " m";
        alltimeHighDateText.text = "Date: " +
            string.Format("{0:N2}", PlayerPrefs.GetString("AllTimeHighDate"));
    }

    void SaveScore()
    {
        PlayerPrefs.SetFloat("AllTimeHighScore", allTimeHighScore);
        PlayerPrefs.SetString("AllTimeHighDate", allTimeHighDate);
        PlayerPrefs.SetFloat("TodayHighScore", todayHighScore);
        PlayerPrefs.SetString("TodayHighDate", todayHighDate);
        PlayerPrefs.Save();
    }

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
