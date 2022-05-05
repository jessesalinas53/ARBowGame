using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TMP_Text scoreText = null;
    public TMP_Text highScoreText = null;
    public TMP_Text postGameScoreText = null;
    public TMP_Text menuHighScoreText = null;

    //public GameObject startMenuPnl = null;
    //public GameObject restartPnl = null;

    Timer timerScript;

    private void Start()
    {
        OnGameLoad();

        timerScript = GetComponent<Timer>();
    }
    private void Update()
    {
        if (timerScript)
        {
            if (timerScript.timeRemaining <= 0)
            {
                UpdateScoreText();
            }
        }
    }

    public void OnGameLoad()
    {
        if (scoreText && highScoreText)
        {
            score = 0;
            scoreText.text = "Score: 0";
            highScore = PlayerPrefs.GetInt("High Score");
            highScoreText.text = "High Score: " + highScore;
            if (menuHighScoreText) menuHighScoreText.text = "High Score: " + highScore;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScoreText()
    {
        if (postGameScoreText) postGameScoreText.text = "Your Score: " + score;

        if (score > PlayerPrefs.GetInt("High Score", 0))
        {
            Debug.Log("High Score set.");
            PlayerPrefs.SetInt("High Score", highScore);
            highScore = score;
            if (highScoreText) highScoreText.text = "High Score: " + highScore;
        }
    }

    /*
    public void StartButton()
    {
        startMenuPnl.SetActive(false);
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }
    */

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("High Score");
        highScore = 0;
        score = 0;
        if (menuHighScoreText) menuHighScoreText.text = "High Score: " + highScore;
        if (highScoreText) highScoreText.text = "High Score: " + highScore;
    }
}
