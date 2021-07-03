using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartGame : MonoBehaviour
{

    private Logic logic;
    GameOverScreen gameOverScreen = null;
    
    public void NewGame()
    {
        logic.state = Logic.GameState.READY;
        gameOverScreen.Hide();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GameObject.Find("GameOverWindow").GetComponent<GameOverScreen>();
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
