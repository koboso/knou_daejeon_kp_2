using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPTest : MonoBehaviour
{
    private TextMeshProUGUI textVariable;
    public int score = 1;
   // public GameObject tmp;
    private void Awake()
    {
        textVariable = GetComponent<TextMeshProUGUI>();
        textVariable.color = Color.white;
      
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //textVariable.text = score.ToString(); // 이게뭐지?
        score++;
        textVariable.text="This font can't support korean."+score;

  
    }
}
