using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Destroy the GameObject when it's clicked
        Destroy(gameObject);
    }
}


