using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    /// <value>ball impulse force</value>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public static float BallLifeSeconds
    {
        get { return configurationData.BallLifeSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public static float MinSpawnSeconds
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public static float MaxSpawnSeconds
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static int NumberOfBallsPerGame 
    {
        get { return configurationData.NumberOfBallsPerGame; }
    }

    public static int StandardBlockPoints
    { 
        get { return configurationData.StandardBlockPoints; }
    }

    #endregion


    public static ConfigurationData configurationData;

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
