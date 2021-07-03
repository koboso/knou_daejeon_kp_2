using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public static bool isLoading = false;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}