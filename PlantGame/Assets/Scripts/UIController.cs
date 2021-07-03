using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour {
    private Logic logic = null;

    public GameOverScreen GameOverScreen;
    

    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject ftparent = null;

    [SerializeField] private TextMeshProUGUI scoreLine = null;

    void Start() {
        // 로직 정보를 가져오기위함.
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
        ftparent = GameObject.Find("FloatingTextParent");
        scoreLine = GameObject.Find("ScoreLine").GetComponentInChildren<TextMeshProUGUI>();
        if(scoreLine)
        {
            Debug.Log("scoreLine 찾음");
        } else
        {
            Debug.Log("scoreLine 못찾음");
        }
    }

    void Update() {
        switch (logic.state){
            case Logic.GameState.READY:
                if(GameOverScreen)
                {
                    GameOverScreen.Hide();
                }
                // 준비 상태의 UI처리
//                DisplayScoreLine();
                break;
            case Logic.GameState.PLAY:
                
                // 플레이 상태의 UI 처리
                //                DisplayScoreLine();
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

    public void DisplayScoreLine()
    {
     //    Debug.Log("Tree Height: " + logic.treeHeight + ", Bees Killed: " + logic.beesKilled  + "\nGrowth Speed: " + logic.growthSpeed + " m/s");
        if (scoreLine)
            scoreLine.text =
                "Tree Height: " + string.Format("{0:N1}", logic.treeHeight) + "m, Bees Killed: " + logic.beesKilled
                + "\nGrowth Speed: " + logic.growthSpeed + " m/s";

    }

    public void DisplayFloatingText(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, ftparent.transform);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }

    private void GameOver()
    {
        GameOverScreen.Setup(logic.treeHeight);
    }

}
