using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour {
    private Logic logic = null;

    private GameOnScreen gameOnScreen;
    private GameOverScreen gameOverScreen;

    [SerializeField] private GameObject floatingTextPrefab;
    private Transform floatTextTransform = null;

    [SerializeField] private TextMeshProUGUI scoreLine = null;

    void Start() {
        // 로직 정보를 가져오기위함.
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();
        floatTextTransform = transform.Find("FloatingTextParent");

        scoreLine = transform.Find("ScoreLine").GetComponentInChildren<TextMeshProUGUI>();

        gameOnScreen = transform.Find("GameOnScreen").GetComponent<GameOnScreen>();
        gameOverScreen = transform.Find("GameOverScreen").GetComponent<GameOverScreen>();
        gameOverScreen.Hide();
    }

    void Update() {
        switch (logic.state){
            case Logic.GameState.READY:
                // 준비 상태의 UI처리
                GameReady();
                DisplayReadyLine();
                break;
            case Logic.GameState.PLAY:
                DisplayScoreLine();
                break;
            case Logic.GameState.PAUSE:
                // 멈춤 상태의 UI처리
                break;
            case Logic.GameState.GAMEOVER:
                // 게임 오버 상태의 UI처리
                GameOver();
                break;

            case Logic.GameState.CLEAR:
                // 클리어 상태의 UI처리
                break;
        }
        
    }

    private void DisplayScoreLine()
    {
        if (scoreLine)
            scoreLine.text =
                "Tree Height: " + string.Format("{0:N1}", logic.treeHeight) + "m";
    }

    private void DisplayReadyLine()
    {
        if(scoreLine)
            scoreLine.text = "Tree Height: 0.0 m";
    }

    public void DisplayFloatingText(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, floatTextTransform);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }

    private void GameOver()
    {
        if (gameOverScreen)
        {
            gameOverScreen.Setup(logic.treeHeight, logic.beesKilled);
        }
    }

    private void GameReady()
    {
        if (gameOnScreen)
            gameOnScreen.Show();
    }
}
