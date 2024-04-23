using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private int points = 0;

    // Function to add points
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log("Points: " + points);
    }
}