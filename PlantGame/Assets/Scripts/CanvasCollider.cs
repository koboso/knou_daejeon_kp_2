using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCollider : MonoBehaviour
{
//    private Button button;
    public Text txt;

    public void OnClickButton()
    {
        txt.text = "BUTTON CLICKED";
        Debug.Log("Button clicked");
    }
    // Start is called before the first frame update
    void Start()
    {
//        button = GetComponent<Button>();
//        button.onClick.AddListener(OnClickButton);
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            txt.text = "Pressed primary button.";

        if (Input.GetMouseButtonDown(1))
            txt.text = "Pressed secondary button.";

        if (Input.GetMouseButtonDown(2))
            txt.text = "Pressed middle click.";
    }
}
