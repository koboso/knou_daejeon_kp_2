using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // 스타드 'READY!' 화면에서 버튼 클릭하면 실행되는 코드
    public void StartGame()
    {
        GameObject.Find("GameManager").GetComponent<Logic>().state = Logic.GameState.PLAY;
        transform.parent.GetComponent<GameOnScreen>().Hide();
        GameObject.Find("BeeSpawnManager").GetComponent<BeeSpawnManager>().spawnTime = 5f;
    }
}
