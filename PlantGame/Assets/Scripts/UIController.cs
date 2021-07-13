using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 캔버스에서 일어나는 UI 처리
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
            case Logic.GameState.FEVER:
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

    // 스코어 출력
    private void DisplayScoreLine()
    {
        if (scoreLine)
            scoreLine.text =
                "Tree Height: " + string.Format("{0:N1}", logic.treeHeight) + "m";
    }

    // 게임레디 상태에서 스코어라인
    private void DisplayReadyLine()
    {
        if(scoreLine)
            scoreLine.text = "Tree Height: 0.0 m";
    }

    // 플로팅텍스트 출력
    public void DisplayFloatingText(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, floatTextTransform);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }

    // 게임오버시 처리내용
    private void GameOver()
    {
        if (gameOverScreen && gameOverScreen.gameObject.activeInHierarchy == false)
        {
            gameOverScreen.Setup(logic.treeHeight, logic.beesKilled);
        }
    }

    // 게임레디 화면을 표시
    private void GameReady()
    {
        if (gameOnScreen && gameOnScreen.gameObject.activeInHierarchy == false)
            gameOnScreen.Show();
    }
}
