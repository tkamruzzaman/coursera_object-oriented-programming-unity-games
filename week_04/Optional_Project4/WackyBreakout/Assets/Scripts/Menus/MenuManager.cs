using UnityEngine.SceneManagement;
using UnityEngine;

public static partial class MenuManager
{
    public static void GoToMenu(MenuName menuName)
    {
        switch (menuName)
        {
            case MenuName.Main:
                // go to MainMenu scene
                GoToScene(SceneName.MainMenu);
                break;
            case MenuName.Help:
                //go to Help menu
                MainMenu mainMenu = Object.FindObjectOfType<MainMenu>();
                if(mainMenu != null)
                {
                    mainMenu.OpenHelpPanel(true);
                }
                break;
            case MenuName.Difficulty:
                // go to DifficultyMenu scene
                GoToScene(SceneName.Difficulty);
                break;
            case MenuName.Pause:
                // instantiate prefab
                Object.Instantiate(Resources.Load("MenuPrefabs/PauseMenu"));
                break;
            case MenuName.GameOver:
                // instantiate prefab
                Object.Instantiate(Resources.Load("MenuPrefabs/GameOverMenu"));
                break;
        }
    }

    public static void GoToScene(SceneName sceneName)
    {
        SceneManager.LoadScene((int)sceneName);
    }
}
