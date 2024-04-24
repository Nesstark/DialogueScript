using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class
public class InteractableItem : MonoBehaviour
{
    public AddPoints addPointsScript;

    protected virtual void Start()
    {
        // Find the AddPoints script in the scene
        addPointsScript = GameObject.FindObjectOfType<AddPoints>();
    }

    protected virtual void OnMouseDown()
    {
        // Base OnMouseDown behavior
    }
}
