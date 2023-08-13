using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(OnResumeButtonPressed);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        PauseGame();
    }

    private void OnResumeButtonPressed()
    {
        ResumeGame();
    }

    private void OnExitButtonPressed()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        ResumeGame();
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePlayManager.isGamePaused = true;
    }

    public void ResumeGame()
    {
        // unpause game and destroy menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        GamePlayManager.isGamePaused = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
