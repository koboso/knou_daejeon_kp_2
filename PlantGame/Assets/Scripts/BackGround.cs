using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] Transform[] mBackgrounds = null;
    [SerializeField] float mspeed = 0f;

    float bgdHeight = 0f;
    private float bgBottom = 0f;



    void Start()
    {
        float tlength = mBackgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        bgBottom = -tlength;
        //bgBottom = 3;
        bgdHeight = tlength * mBackgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mBackgrounds.Length; i++)

        {
            mBackgrounds[i].position += new Vector3(0, mspeed, 0) * Time.deltaTime;

            if (mBackgrounds[i].position.y < bgBottom) // 수정하자. 셀프가 안올라가게. 스테이지가 언제까지 계속되는지 체크
            {
                Vector3 selfPos = mBackgrounds[i].position;
                selfPos.Set(selfPos.x, bgBottom - selfPos.y, selfPos.z);
                mBackgrounds[i].position = selfPos;

                Debug.Log("bgHeight = " + bgdHeight);
                Debug.Log("bgBottom = " + bgBottom);
            }

        }

        //if (mBackgrounds[i].position.y < bgBottom)
        //{
        //    Vector3 selfPos = mBackgrounds[i].position;
        //    selfPos.Set(selfPos.x, bgBottom - selfPos.y, selfPos.z);
        //    mBackgrounds[i].position = selfPos;

        //    Debug.Log("bgHeight = " + bgdHeight);
        //    Debug.Log("bgBottom = " + bgBottom);
        //}


        //    if (transform.position.y <= bgBottom)
        //    {
        //        Reposition();
        //    }
        //        Debug.Log("bgHeight = " + bgdHeight);
        //        Debug.Log("bgBottom = " + bgBottom);
        //}
        //private void Reposition()
        //    {
        //        Vector2 offset = new Vector2(0,bgBottom * 2f);
        //        transform.position = (Vector2)transform.position + offset;
        //    }

    }
}