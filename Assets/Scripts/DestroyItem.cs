using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour
{
    public AddPoints addPointsScript;

    private void Start()
    {
        // Find the AddPoints script in the scene
        addPointsScript = GameObject.FindObjectOfType<AddPoints>();
    }

    private void OnMouseDown()
    {
        // Destroy all child GameObjects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Call AddScore() method from AddPoints script if addPointsScript is not null
        if (addPointsScript != null)
        {
            addPointsScript.AddScore();
        }

        // Destroy the GameObject when it's clicked
        Destroy(gameObject);
    }
}



