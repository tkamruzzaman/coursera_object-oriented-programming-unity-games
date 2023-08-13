using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    static int ballsLeft = 0;
    static Text ballsLeftText;

    // score text support
    const string ScorePrefix = "Score: ";
    static int score = 0;
    static Text scoreText;

    // last ball lost support
    LastBallLostEvent lastBallLostEvent = new LastBallLostEvent();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the score
    /// </summary>
    public int Score
    {
        get { return score; }
    }

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

        // add listeners to event manager
        EventManager.AddBallLostListener(LoseBall);
        EventManager.AddPointsAddedListener(AddPoints);

        // add invoker to event manager
        EventManager.AddLastBallLostInvoker(this);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given listener for the LastBallLostEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostEvent.AddListener(listener);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Reduces the number of balls left
    /// </summary>
    void LoseBall()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
        if (ballsLeft == 0)
        {
            lastBallLostEvent.Invoke();
        }
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
