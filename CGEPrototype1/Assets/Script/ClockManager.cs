using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    public TMP_Text textbox;

    private bool isGameRunning = false;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        StartClock();
    }

    void StartClock()
    {
        isGameRunning = true;
        startTime = Time.time;
        // Call UpdateClock function every second
        InvokeRepeating("UpdateClock", 0, 1);
    }

    void StopClock()
    {
        isGameRunning = false;
        // Stop updating the clock
        CancelInvoke("UpdateClock");
    }

    void ResetClock()
    {
        startTime = Time.time;
    }

    void UpdateClock()
    {
        // If the game is not running, exit the function
        if (!isGameRunning)
            return;

        // Calculate elapsed time
        float elapsedTime = Time.time - startTime;

        // Convert elapsed time to hours, minutes, and seconds
        int hours = (int)(elapsedTime / 3600) % 24;
        int minutes = (int)(elapsedTime / 60) % 60;
        int seconds = (int)elapsedTime % 60;

        // Format time as HH:mm:ss
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        // Update the text of the clock UI element
        textbox.text = timeString;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the 'R' key press to reset the clock
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetClock();
        }
    }
}
