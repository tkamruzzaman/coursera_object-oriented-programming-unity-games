using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A block
/// </summary>	
public class Block : MonoBehaviour
{
    private int blockPoints = 1;
    protected int BlockPoints
    {
        get { return blockPoints; }
        set { blockPoints = value; }
    }

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {

    }

    /// <summary>
	/// Update is called once per frame
	/// </summary>	
    void Update()
    {
        
    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            HUD.UpdateScore();
            Destroy(gameObject);
        }
    }

    #endregion
}
