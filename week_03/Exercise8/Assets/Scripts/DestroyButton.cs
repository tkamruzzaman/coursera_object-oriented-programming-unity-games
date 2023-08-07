using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestroyButton : MonoBehaviour
{
    [SerializeField] Button button;

    DestroyEvent destroyEvent = new DestroyEvent();

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            OnButtonClicked();
        });
        EventManager.AddInvoker(this);
    }

    public void AddDestroyEventListener(UnityAction unityAction)
    {
        destroyEvent.AddListener(unityAction);
    }

    public void OnButtonClicked()
    {
        Debug.Log("Destroy button pressed!");

        destroyEvent.Invoke();
    }
}
