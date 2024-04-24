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
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Shake();
                AudioManager.instance.PlaySound(12);

                if (addPointsScript != null)
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

    public void Shake()
    {
        currentShakeDuration = shakeDuration;
    }
}
