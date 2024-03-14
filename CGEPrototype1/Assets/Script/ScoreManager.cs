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
            textbox.text = "Cherries: " + score;
        }
        if(score>=scoreToWin)
        {
            won = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win! \n Press R to play again";

            }
            else
            {
                textbox.text = "You lose! \n Press R to try again";
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}