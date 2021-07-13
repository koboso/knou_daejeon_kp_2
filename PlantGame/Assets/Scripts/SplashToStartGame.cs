using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// splash 스크린 
public class SplashToStartGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu() 
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
