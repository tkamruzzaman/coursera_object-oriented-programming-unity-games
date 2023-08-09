using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A HUD
/// </summary>	
public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject ballsLeftTextGameObject;
    [SerializeField]
    GameObject scoreTextGameObject;

    // balls left text support
    const string BallsLeftPrefix = "Balls Left: ";
    int ballsLeft = 0;
    Text ballsLeftText;

    // score text support
    const string ScorePrefix = "Score: ";
    int score = 0;
    Text scoreText;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = ballsLeftTextGameObject.GetComponent<Text>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();

        score = 0;
        scoreText = scoreTextGameObject.GetComponent<Text>();
        scoreText.text = ScorePrefix + score.ToString();

        EventManager.AddBallLostListener(LoseBall);

        EventManager.AddAddPointsListener(AddPoints);
    } 

    #endregion

    #region Public methods

    /// <summary>
    /// Reduces the number of balls left
    /// </summary>
    void LoseBall()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
    }

    /// <summary>
    /// Adds the given points to the score
    /// </summary>
    /// <param name="points">points to add</param>
    void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }

    #endregion
}
