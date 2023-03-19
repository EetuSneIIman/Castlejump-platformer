using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdUI : MonoBehaviour
{
    public void ToADTest()
    {
        SceneManager.LoadScene("AdTestScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
