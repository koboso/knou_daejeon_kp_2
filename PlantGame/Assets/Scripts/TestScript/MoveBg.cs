using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBg : MonoBehaviour
{
    public float speed = 1f; // 백그라운도 이동 스피드
    public float clamppos; // clamping position

    [HideInInspector] public Vector3 StartPosition; // get out first position

    void Start()
    {
        StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        float NewPosition = Mathf.Repeat(Time.time * speed, clamppos);
        transform.position = StartPosition + Vector3.up * NewPosition;
    }
}
