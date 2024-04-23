using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour
{
    public int score;
    public Text scoreText;
 
    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    }

    public void SubtractScore()
    {
        if(score > 0)
        {
            score--;
        }
    }
}

