using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText,hightscoreText; // Teks untuk menampilkan skor
    private float score; // Skor
    private float sp = 1f;
    void Start()
    {
        score = 0;
        hightscoreText.text = "HighScores: " + PlayerPrefs.GetFloat("HighScore").ToString("0");
    }

    void Update()
    {
        AddScore();
    }
    // Fungsi untuk menambah skor
    public void AddScore()
    {
        score += sp*Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");
        PlayerPrefs.SetFloat("HighScore", score);
    }
}
