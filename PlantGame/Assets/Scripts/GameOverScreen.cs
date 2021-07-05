using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text treeHeight;
    public Text beesKilled;

    public void Setup(float score, int bee)
    {
        gameObject.SetActive(true);
        treeHeight.text = "Tree is grown " + string.Format("{0:N2}", score) + " m";
        beesKilled.text = "\nBees Killed: " + bee;
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
