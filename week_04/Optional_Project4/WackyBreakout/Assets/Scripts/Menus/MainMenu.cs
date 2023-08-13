using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button exitButton;
    [Space]
    [Space]
    [SerializeField] private RectTransform helpPanel;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonPressed);
        }

        if (helpButton != null)
        {
            helpButton.onClick.AddListener(OnHelpButtonPressed);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        if(backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonPressed);
        }

        OpenHelpPanel(false);
    }

    private void OnPlayButtonPressed()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    private void OnHelpButtonPressed()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }

    private void OnExitButtonPressed()
    {
        Application.Quit();
    }

    private void OnBackButtonPressed()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        //OpenHelpPanel(false);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void OpenHelpPanel(bool status)
    {
        if(helpPanel != null)
        {
            helpPanel.gameObject.SetActive(status);
        }
    }

}
