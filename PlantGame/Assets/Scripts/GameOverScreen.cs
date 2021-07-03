using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text treeHeight;

    public void Setup (float score)
    {
        gameObject.SetActive(true);
        treeHeight.text = "Tree is grown " + string.Format("{0:N2}", score) + " m";
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
