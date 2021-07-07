using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour
{
    private MeshRenderer render;

    Logic logic;

    public float speed;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "ingame")
        {
            if (logic.state == Logic.GameState.PLAY || logic.state == Logic.GameState.FEVER)
            {
                offset += Time.deltaTime * speed;
                render.material.mainTextureOffset = new Vector2(offset, 0);
            }
        }
        else
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
