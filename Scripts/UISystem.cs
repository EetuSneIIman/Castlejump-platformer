using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    public Text highScoreText;
   

    void Update()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore1", 0).ToString("f0");
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("2D Scene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    


}
