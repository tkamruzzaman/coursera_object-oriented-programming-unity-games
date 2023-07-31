using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text ballsLeftText;
    [SerializeField] TMP_Text scoreText;

    static int ballLeft;
    static int score;

    static HUD instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ballLeft = ConfigurationUtils.NumberOfBallsPerGame;
        score = 0;
        ballsLeftText.text = "Balls Left: " + ballLeft.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public static void UpdateBallLeft()
    {
        ballLeft--;
        instance.ballsLeftText.text = "Balls Left: " + ballLeft.ToString();
    }

    public static void UpdateScore()
    {
        score++;
        instance.scoreText.text = "Score: " + score.ToString();
    }
}
