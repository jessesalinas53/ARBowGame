using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Text timerText;
    public GameObject restartPanel;

    Score Score;

    void Update()
    {
        if(timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                restartPanel.SetActive(true);
                Score.UpdateScoreText();
            }
        }
        
        DisplayText(timeRemaining);
    }

    void DisplayText(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;
        timerText.text = string.Format("Time: {0:00}:{1:00}", seconds, milliSeconds);
    }

    public void StartTimer()
    {
        
        timeRemaining = 5;
        timerIsRunning = true;
        restartPanel.SetActive(false);

    }
}
