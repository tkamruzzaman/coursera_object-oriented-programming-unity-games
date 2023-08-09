using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bonus block
/// </summary>	
public class BonusBlock : Block
{
    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    protected override void Start()
    {
        Points = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }

    /// <summary>
	/// Update is called once per frame
	/// </summary>	
    void Update()
    {
        
    }

    #endregion
}
