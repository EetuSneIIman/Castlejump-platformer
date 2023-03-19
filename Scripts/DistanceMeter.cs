using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMeter : MonoBehaviour
{
    // Reference to checkpoint position
    [SerializeField]
    private Transform checkpoint;

    // Reference to UI text that shows the distance value
    [Header("Objects")]
    public Text distanceText;
    public Text distanceTextEnd;
    public Text highScoreText;
    public GameObject newHighScore;

    // Calculated distance value
    public float distance;



    void Awake()
    {
        //PlayerPrefs.SetFloat("HighScore1", 0);
    }


    // Update is called once per frame
    private void Update()
    {

        // Calculate distance value by X axis
        distance = (checkpoint.transform.position.y + transform.position.y);
        Debug.Log("Distance: " + distance);

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        // so 12.234 will be shown as 12.2 for example
        // distance.ToString("F2") will show 12.23 in this case
        distanceText.text = distance.ToString("0");
        distanceTextEnd.text = distance.ToString("f0");

        highScoreText.text = PlayerPrefs.GetFloat("HighScore1", 0).ToString("f0");

        if (distance > PlayerPrefs.GetFloat("HighScore1", 0))
        {
            PlayerPrefs.SetFloat("HighScore1", distance);
            highScoreText.text = distance.ToString("f0");
            newHighScore.SetActive(true);
        }
    }
}
