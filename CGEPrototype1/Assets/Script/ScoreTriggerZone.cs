using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    public AudioClip triggerSound; // Sound to play when trigger is hit
    private AudioSource audioSource;

    // You may not need this variable if you don't plan to prevent multiple score increments
    bool active = true;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger zone is active (optional)
        if (active)
        {
            // If active, prevent further interactions
            active = false;

            // Increment score
            ScoreManager.score++;

            // Play the trigger sound
            if (triggerSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }
        }

        // Check if the colliding object is tagged as "Cherry"
        if (collision.CompareTag("Cherry"))
        {
            // Destroy the trigger zone GameObject
            Destroy(gameObject); // Or use: gameObject.SetActive(false);
        }
    }
}


