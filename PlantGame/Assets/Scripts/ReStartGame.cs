using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartGame : MonoBehaviour
{

    public void NewGame()
    {
        GameObject.Find("GameManager").GetComponent<Logic>().state = Logic.GameState.READY;
        GameObject.Find("GameOverScreen").GetComponent<GameOverScreen>().Hide();
    }

}
