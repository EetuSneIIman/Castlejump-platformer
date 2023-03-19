using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameObject deadScreen;
    public GameObject Scores;
    public GameObject moveButtons;
    public bool dead = false;

    void Update()
    {
        if (dead)
        {
            Time.timeScale = 0f;
            deadScreen.SetActive(true);
            Scores.SetActive(false);
            moveButtons.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        dead = true;
    }
}
