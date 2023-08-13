using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>	
public class Block : MonoBehaviour
{
    #region Fields

    // scoring support
    int points;
    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();
    BlockDestroyedEvent blocksDestroyedEvent = new BlockDestroyedEvent();

    #endregion

    #region Protected properties

    /// <summary>
    /// Sets the points the block is worth
    /// </summary>
    protected int Points
    {
        set { points = value; }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    virtual protected void Start()
    {
        // add as invoker of events
        EventManager.AddPointsAddedInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            AudioManager.Play(AudioClipName.BallCollision);
            pointsAddedEvent.Invoke(points);
            EventManager.RemovePointsAddedInvoker(this);
            blocksDestroyedEvent.Invoke();
            EventManager.RemoveBlockDestroyedInvoker(this);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given listener for the PointsAddedEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    internal void AddBlockDestroyedListener(UnityAction listener)
    {
        blocksDestroyedEvent.AddListener(listener);
    }

    #endregion
}
