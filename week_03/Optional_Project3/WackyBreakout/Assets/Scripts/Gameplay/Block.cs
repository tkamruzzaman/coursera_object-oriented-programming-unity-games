using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>	
public class Block : MonoBehaviour
{
    #region Fields

    int points;

    PointsAddedEvent OnPointsAdded = new PointsAddedEvent();

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
    protected virtual void Start()
    {
        EventManager.AddAddPointsInvoker(this);
    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            OnPointsAdded.Invoke(points);
            EventManager.RemoveAddPointsInvoker(this);
            Destroy(gameObject);
        }
    }
    #endregion

    public void AddAddPointsListener(UnityAction<int> listener)
    {
        OnPointsAdded.AddListener(listener);
    }

}
