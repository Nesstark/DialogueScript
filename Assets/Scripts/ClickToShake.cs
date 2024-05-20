using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Derived class from InteractableItem for clicking to shake behavior
public class ClickToShake : InteractableItem
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;
    private float currentShakeDuration = 0f;

    protected override void Start()
    {
        originalPos = transform.position;
        base.Start();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) //If the 'wrong' item is clicked
            {
                Shake(); //Makes the item shake
                AudioManager.instance.PlaySound(12); //Plays the chosen sound

                if (addPointsScript != null) //Subtracts points from the score
                {
                    addPointsScript.SubtractScore();
                }
            }
        }

        if (currentShakeDuration > 0)
        {
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.position = originalPos;
        }
    }

    public void Shake() //Makes the item shake
    {
        currentShakeDuration = shakeDuration;
    }
}

//This script is written with some help of ChatGPT. 