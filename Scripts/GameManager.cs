using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deadScreen;
    public GameObject Scores;
    public GameObject NewHighScore;

    void Awake()
    {
        Time.timeScale = 1f;

        GameObject.Find("Canvas").GetComponent<UISystem>();
        
        deadScreen.SetActive(false);
        Scores.SetActive(true);
        NewHighScore.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif

        }
    }
}
