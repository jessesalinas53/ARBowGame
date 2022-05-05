using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public TMP_Text timerText = null;

    private float _initTime;

    private void Start()
    {
        _initTime = timeRemaining;
    }

    void Update()
    {
        CustomTimer();
    }

    private void CustomTimer()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayText(timeRemaining);
            }
            else
            {
                OutOfTime();
            }
        }

    }

    public void OutOfTime()
    {
        timeRemaining = 0;
        timerIsRunning = false;
        timeRemaining = _initTime;
        GetComponent<GameManager>().GameOver();
    }

    private void DisplayText(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;
        if (timerText) timerText.text = string.Format("Time: \n{0:00}:{1:00}", seconds, milliSeconds);
    }
}
