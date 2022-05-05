using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText = null;
    public TMP_Text highScoreText = null;
    public TMP_Text postGameScoreText = null;
    public TMP_Text menuHighScoreText = null;

    private void Update()
    {
        if (GameManager.Instance.CurrentScene == 1)
        {
            if (scoreText) scoreText.text = "Score: \n" + GameManager.Instance.Score;
        }
    }

    public void OnGameLoad()
    {
        if (highScoreText) highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
        if (menuHighScoreText) menuHighScoreText.text = "High Score: " + GameManager.Instance.HighScore;
    }

    public void UpdateScoreText()
    {
        int score = GameManager.Instance.Score;

        if (postGameScoreText) postGameScoreText.text = "Your Score: " + score;

        if (score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", score);
            GameManager.Instance.HighScore = score;
            if (highScoreText) highScoreText.text = "High Score: " + score;
        }
        else if (!PlayerPrefs.HasKey("High Score") || PlayerPrefs.GetInt("High Score") == 0)
        {
            PlayerPrefs.SetInt("High Score", score);
            GameManager.Instance.HighScore = score;
            if (highScoreText) highScoreText.text = "High Score: " + score;
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("High Score");
        GameManager.Instance.HighScore = 0;
        if (menuHighScoreText) menuHighScoreText.text = "High Score: " + GameManager.Instance.HighScore;
        if (highScoreText) highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
    }
}
