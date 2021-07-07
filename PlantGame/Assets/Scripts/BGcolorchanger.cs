using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGcolorchanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public enum BGState { DAY = 0, NIGHT };
    public BGState state = BGState.DAY;
    private float offset = 1f;
    private float speed = 0.0025f;
    private Logic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();

        spriteRenderer = GetComponent<SpriteRenderer>();

       
    }
    public void BGLogic()
    {
        switch (state)
        {
            case BGState.DAY:
                break;
            case BGState.NIGHT:
                break;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        BGLogic();
        if (this.tag == "ingame")
        {
            if (GameObject.Find("GameManager").GetComponent<Logic>().state == Logic.GameState.PLAY)
            {
                if (state == BGState.DAY)
                {
                    offset -= speed * logic.treeHeight / 1000;
                    spriteRenderer.color = Color.HSVToRGB(1, 0, offset);
                    if (offset < 0.3)
                    {
                        Debug.Log("밤이 됩니다");
                        state = BGState.NIGHT;
                        offset += speed * logic.treeHeight / 1000;
                    }
                }
                else
                {
                    offset += speed * logic.treeHeight / 1000;
                    spriteRenderer.color = Color.HSVToRGB(1, 0, offset);
                    if (offset > 1)
                    {
                        Debug.Log("낮이 됩니다");
                        state = BGState.DAY;
                        offset -= speed * logic.treeHeight / 1000;
                    }
                }


            }
            else if (GameObject.Find("GameManager").GetComponent<Logic>().state == Logic.GameState.READY)
            {
                spriteRenderer.color = Color.HSVToRGB(1, 0, 1);
            }
        }
    }
}
