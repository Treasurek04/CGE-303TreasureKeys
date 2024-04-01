using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    public TMP_Text textbox;

    public int scoreToWin;

    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    void Update()
    {
        if (!gameOver)
        {
            {
                textbox.text = "Cherries: " + score;
            }
           
            if (score >= scoreToWin)
            {
                GameOver(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void GameOver(bool result)
    {
        won = result;
        gameOver = true;
    }
}