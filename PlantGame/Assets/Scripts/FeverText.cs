using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//피버모드일 때 뜨는 피버텍스트
public class FeverText : MonoBehaviour
{
    public float moveSpeed;//위쪽으로 움직일 속도
    public float alphaSpeed;//투명도 조절속도
    public float destroyTime;//일정시간 유지 후 삭제될 시간
    private float time;
    TextMeshPro text;
    Color alpha;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        time = Time.deltaTime;
        Invoke("DestroyObject",destroyTime);//삭제시간에 맞춰 오브젝트 삭제
    }

    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * time, 0));//위쪽으로 이동
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * time);//알파값 조정
        text.color = alpha;
        time = Time.deltaTime;
    }

    //오브젝트 삭제
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
