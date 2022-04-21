using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public TMP_Text timerText;
    public GameObject restartPanel;
    public GameObject gameCanvas;

    private float _initTime;

    private void Start()
    {
        _initTime = timeRemaining;
    }

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
                gameCanvas.SetActive(false);
                timeRemaining = _initTime;
                GetComponent<TouchInput>().enabled = false;
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
        timerIsRunning = true;
        restartPanel.SetActive(false);
    }
}
