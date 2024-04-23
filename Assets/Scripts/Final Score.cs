using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSceneScript : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Get the score from PlayerPrefs and display it
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Your Final Score: " + score.ToString();
    }
}
