using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text postGameScoreText;
    public TMP_Text menuHighScoreText;

    public GameObject startMenuPnl;
    public GameObject restartPnl;

    Timer timerScript;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: 0";
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score: " + highScore;
        menuHighScoreText.text = "High Score: " + highScore;

        timerScript = GetComponent<Timer>();
    }
    private void Update()
    {
        if(timerScript.timeRemaining <= 0)
        {
            UpdateScoreText();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    public void UpdateScoreText()
    {
        postGameScoreText.text = "Your Score: " + score;

        if(score > PlayerPrefs.GetInt("High Score", 0))
        {
            Debug.Log("High Score set.");
            PlayerPrefs.SetInt("High Score", highScore);
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void StartButton()
    {
        startMenuPnl.SetActive(false);
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("High Score");
        highScore = 0;
        score = 0;
        menuHighScoreText.text = "High Score: " + highScore;
        highScoreText.text = "High Score: " + highScore;
    }

    public void ReturnToMenu()
    {
        startMenuPnl.SetActive(true);
        menuHighScoreText.text = "High Score: " + highScore;
        restartPnl.SetActive(false);
    }
}
