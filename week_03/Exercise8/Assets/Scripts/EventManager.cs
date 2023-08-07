using UnityEngine.Events;

public static class EventManager
{
    static DestroyButton invoker;
    static UnityAction unityAction;

    public static void AddInvoker(DestroyButton destroyButton)
    {
        invoker = destroyButton;
        if(unityAction != null)
        {
            invoker.AddDestroyEventListener(unityAction);
        }
    }

    public static void AddListener(UnityAction listener)
    {
        unityAction = listener;
        if(invoker != null)
        {
            invoker.AddDestroyEventListener(unityAction);
        }
    }
}
