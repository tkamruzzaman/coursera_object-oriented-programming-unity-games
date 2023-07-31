﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data with default values
    static float teddyBearMoveUnitsPerSecond = 5;
    static float cooldownSeconds = 1;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public float TeddyBearMoveUnitsPerSecond
    {
        get { return teddyBearMoveUnitsPerSecond; }
    }
        
    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public float CooldownSeconds
    {
        get { return cooldownSeconds; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file

		StreamReader reader = null;
		try
		{
			reader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

			string names = reader.ReadLine();
			string values = reader.ReadLine();

			SetConfigurationDataFields(values);
		}
		catch (Exception e)
		{
			Debug.LogError (e);
		}
		finally
		{               
			// always close input file
			if (reader != null)
			{
				reader.Close();
			}
		}
    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
		string[] values = csvValues.Split(',');

		teddyBearMoveUnitsPerSecond = float.Parse (values [0]);
		cooldownSeconds = float.Parse (values [1]);
    }

    #endregion
}
