using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_Text scoreText;
    [Space]
    [SerializeField] private Button exitButton;

    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        Time.timeScale = 0;
        GamePlayManager.isGameOver = true;

        HUD hud = FindObjectOfType<HUD>();  
        if (hud != null)
        {
            SetScore(hud.Score);
        }
        SetMessage(GamePlayManager.isGameSuccess);
        if(!GamePlayManager.isGameSuccess) { LooserSound(); }
    }

    private void OnExitButtonPressed()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        GamePlayManager.isGameOver = false;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    private void SetScore(int score)
    {
        scoreText.text = "Your Score: " + score.ToString();
    }

    private void SetMessage(bool win)
    {
        messageText.text = win? "Congratulations! \n You WON!" : "You Lost!";
    }

    private void LooserSound()
    {
        AudioManager.Play(AudioClipName.GameLost);
    }
}
