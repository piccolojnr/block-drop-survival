using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;

    private int highScore = 0;

    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        LoadScore();
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SaveScore()
    {
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void LoadScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        scoreText.text = "Score: " + score + "\nHigh Score: " + highScore;
    }
}
