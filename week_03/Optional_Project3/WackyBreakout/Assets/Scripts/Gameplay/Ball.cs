using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>	
public class Ball : MonoBehaviour
{
    #region Fields

    // move delay timer
    Timer moveTimer;

    // death timer
    Timer deathTimer;

    BallDiedEvent OnBallDiedEvent = new BallDiedEvent();
    BallLostEvent OnBallLostEvent = new BallLostEvent();

    Timer speedupTimer;
    float speedupFactor;

    Rigidbody2D rb2d;
    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
        moveTimer.AddTimerFinishedListener(() => {
            // move when time is up
            //print("Move Timer Finished!");
            moveTimer.Stop();
            StartMoving();
        });

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
        deathTimer.AddTimerFinishedListener(() => {
            // spawn new ball and destroy self
            //print("Death Timer Finished!");
            OnBallDiedEvent.Invoke();
            RemoveBall();
        });

        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);

        rb2d = GetComponent<Rigidbody2D>();

        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(BacktoNormalSpeed);
        EventManager.AddSpeedupEffectActivateListener(SpeedupEffect);
    }

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                OnBallLostEvent.Invoke();
            }
            RemoveBall();
        }
    }

    private void RemoveBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        EventManager.RemoveSpeedupEffectActivateListener(SpeedupEffect);
       
        Destroy(gameObject);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    public void AddBallDiedListener(UnityAction action)
    {
        OnBallDiedEvent.AddListener(action);
    }

    public void AddBallLostListener(UnityAction action)
    {
        OnBallLostEvent.AddListener(action);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

      if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.SpeedupEffectSecondsLeft,
                EffectUtils.SpeedupFactor);
            force *= speedupFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(force);
    }

    private void SpeedupEffect(float duration, float factor)
    {
        if (!speedupTimer.Running)
        {
            StartSpeedupEffect(duration, factor);
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }

    private void BacktoNormalSpeed()
    {
        speedupTimer.Stop();
        //print(speedupFactor);
        rb2d.velocity *= 1 / speedupFactor;

    }

    #endregion
}
