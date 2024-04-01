using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public TMP_Text textbox;

    void Start()
    {
        // Initially hide the text
        textbox.enabled = false;
    }

    void Update()
    {
        // Check if the game is over
        if (ScoreManager.gameOver)
        {
            // Show the text when game over
            textbox.enabled = true;

            if (ScoreManager.won)
            {
                textbox.text = "You Win! Click R to Replay";  // Set text for win
            }
            else
            {
                textbox.text = "You Lose :( Click R to Replay";
            }
          
            // Check if 'R' key is pressed to restart the game
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            // Hide the text during gameplay
            textbox.enabled = false;
        }
    }
}
