using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
	void Awake()
    {
        // initialize various utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
        DifficultyUtils.Initialize();
    }
}
