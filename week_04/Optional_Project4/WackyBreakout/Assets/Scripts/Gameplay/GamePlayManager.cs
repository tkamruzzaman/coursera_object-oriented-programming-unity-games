using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static bool isGamePaused;
    public static bool isGameOver;
    public static bool isGameSuccess;

    private void Start()
    {
        EventManager.AddLastBallLostListener(LastBallLostCallback);
        EventManager.AddBlockDestroyedListener(BlockDestroyedCallBack);
    }

    private void Update()
    {
        if (isGameOver) { return; }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
                if (pauseMenu != null) { pauseMenu.ResumeGame(); return; }
            }
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    private void LastBallLostCallback()
    {
        isGameSuccess = false;
        EndGamePlay();
    }

    private void BlockDestroyedCallBack()
    {
        if (FindObjectsOfType<Block>().Length == 1)
        {
            isGameSuccess = true;
            EndGamePlay();
        }
    }

    private void EndGamePlay()
    {
        MenuManager.GoToMenu(MenuName.GameOver);
    }
}
