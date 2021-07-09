using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeverText : MonoBehaviour
{
    public float moveSpeed;
    public float alphaSpeed;
    public float destroyTime;
    private float time;
    TextMeshPro text;
    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        time = Time.deltaTime;
        Invoke("DestroyObject",destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * time, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * time);
        text.color = alpha;
        time = Time.deltaTime;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
