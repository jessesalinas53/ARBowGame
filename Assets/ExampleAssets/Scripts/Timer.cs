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
        // auto setting timeRemaining regardless of user input
        //timeRemaining = 5;
        timerIsRunning = true;
        restartPanel.SetActive(false);
    }
}
