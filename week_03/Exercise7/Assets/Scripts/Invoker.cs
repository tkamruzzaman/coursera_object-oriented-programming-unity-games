using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Invoker : MonoBehaviour
{
    Timer timer;
    MessageEvent messageEvent;

    private void Awake()
    {
        messageEvent = new MessageEvent();
    }

    private void Start()
    {
        timer = Camera.main.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
    }

    private void Update()
    {
        if (timer != null && timer.Finished)
        {
            messageEvent.Invoke();
            timer.Run();
        }
    }

    public void AddEventListener(UnityAction unityAction)
    {
        messageEvent.AddListener(unityAction);
    }
}