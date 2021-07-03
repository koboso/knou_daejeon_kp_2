using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    private Logic logic;
    private GameOnScreen GameOnScreen;

    public void StartGame()
    {
        if (GameOnScreen)
        {
            GameOnScreen.Hide();
        }
        logic.state = Logic.GameState.PLAY;
    }


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
        GameOnScreen = GameObject.Find("GameStart").GetComponent<GameOnScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
