using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 애니메이션 text를 1초 후에 삭제
public class FloatingText : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }
}
