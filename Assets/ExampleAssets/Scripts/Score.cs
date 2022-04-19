using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text highScoreText;
    public Text yourScoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    public void UpdateScoreText()
    {
        yourScoreText.text = "Your Score: " + score;
    }
}
