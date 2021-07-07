using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour
{
    private MeshRenderer render;

    public float speed;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<Logic>().state == Logic.GameState.PLAY)
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
