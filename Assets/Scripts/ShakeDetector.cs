using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public float ShakeDetectionThreshold = 2.0f;
    public float MinShakeInterval = 0.5f;
    public float ShakeIntensityMultiplier = 1.5f; // New variable to control shake intensity

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;
    private Vector3 initialPosition;

    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            timeSinceLastShake = Time.unscaledTime;
            Debug.Log("Shake event detected at time " + Time.unscaledTime);
            Shake();
        }
    }

    void Shake()
    {
        float shakeIntensity = 0.1f * ShakeIntensityMultiplier; // Multiply shake intensity by ShakeIntensityMultiplier
        float shakeDuration = 0.2f;

        StartCoroutine(ShakeCoroutine(shakeIntensity, shakeDuration));
    }

    IEnumerator ShakeCoroutine(float intensity, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * intensity;
            transform.position = initialPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;
    }
}