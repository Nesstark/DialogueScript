using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Get the score from PlayerPrefs and display it
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Din endelige Score: " + score.ToString();

    }
}
