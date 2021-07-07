using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverMode : MonoBehaviour
{
    private Logic logic = null;
    [SerializeField]
    private Slider feverbar;

    private float fevertime = 5f;

    private int maxFever = 10;
    private int curFever = 0;
    // Start is called before the first frame update
    void Start()
    {
        //로직 가져옴
        logic = GameObject.Find("/GameManager").GetComponent<Logic>();

        feverbar.maxValue = maxFever;
        feverbar.value = curFever;
    }

    // Update is called once per frame
    void Update()
    {
        //맥스포인트 전까지 벌 죽을 때마다 올라가는 피버포인트로 포인트 증가
        if(curFever < maxFever)
        {
            curFever = logic.feverpoint;
        }
        else
        {
            //맥스포인트 되면 피버타임 타이머 시작
            fevertime -= Time.deltaTime;
            Debug.Log("피버타임");

            //피버타임 끝나면 피버포인트 초기화
            if (fevertime < 0)
            {
                Debug.Log("피버타임 끝");
                logic.feverpoint = 0;
                curFever = 0;
                fevertime = 5f;
            }
        }
        HandleFever();
    }
    private void HandleFever()
    {
        feverbar.value = curFever;
    }
}
