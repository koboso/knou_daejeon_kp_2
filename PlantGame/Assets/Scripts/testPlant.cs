using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlant : MonoBehaviour
{
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //충돌 시 지정 색상으로 변화
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = color;

    }

}