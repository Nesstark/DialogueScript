using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



// Derived class from InteractableItem for destroying items
public class DestroyItem : InteractableItem
{
    public static int itemsClicked = 0; // Static variable to count the items clicked

    protected override void Start()
    {
        base.Start();
        // Additional Start functionality for DestroyItem

        itemsClicked = 0; // Sets the items clicked to 0 when starting the game (necessary in order to replay the game)
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        // Destroy all child GameObjects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
            AudioManager.instance.PlaySound(9);
        }

        if (addPointsScript != null)
        {
            addPointsScript.AddScore();
        }

        itemsClicked++; // Increment the count of items clicked
        Destroy(gameObject);

        if (itemsClicked >= 10)
        {
            PlayerPrefs.SetInt("Score", addPointsScript.score);
            SceneManager.LoadScene("Game Done");
        }
    }
}

//This script is written with some help of ChatGPT. 

