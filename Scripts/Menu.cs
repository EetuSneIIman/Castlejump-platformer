using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject CreditMenu;
    public GameObject MainMenu;

    void Awake()
    {
        CreditMenu.SetActive(false);
        MainMenu.SetActive(true);
        Time.timeScale = 0f;
    }




    public void Play()
    {
        SceneManager.LoadScene("2D Scene");
    }

    public void CreditButton()
    {
        CreditMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void BackToMenuButton()
    {
        CreditMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
