using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private Button easyGameButton;
    [SerializeField] private Button mediumGameButton;
    [SerializeField] private Button hardGameButton;

    private GameStartedEvent gameStartedEvent = new GameStartedEvent();

    private void Start()
    {
        if (easyGameButton != null)
        {
            easyGameButton.onClick.AddListener(OnEasyGameButtonPressed);
        }
        if (mediumGameButton != null)
        {
            mediumGameButton.onClick.AddListener(OnMediumGameButtonPressed);
        }
        if (hardGameButton != null)
        {
            hardGameButton.onClick.AddListener(OnHardGameButtonPressed);
        }

        EventManager.AddGameStartedInvoker(this);
    }

    private void OnEasyGameButtonPressed()
    {
        //AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Easy);
    }

    private void OnMediumGameButtonPressed()
    {
        //AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Medium);
    }

    private void OnHardGameButtonPressed()
    {
        //AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Hard);
    }


    public void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }


}
