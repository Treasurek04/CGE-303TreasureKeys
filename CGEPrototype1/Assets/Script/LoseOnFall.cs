using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseOnFall : MonoBehaviour
{
    public float lowestY; // Y-axis threshold for triggering loss

    void Update()
    {
        // Check if the GameObject falls below the threshold
        if (transform.position.y <= lowestY)
        {
            // Trigger a loss
            ScoreManager.gameOver = true;
        }
    }
}
