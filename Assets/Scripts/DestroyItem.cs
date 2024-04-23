using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Destroy all child GameObjects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Destroy the GameObject when it's clicked
        Destroy(gameObject);
    }
}


