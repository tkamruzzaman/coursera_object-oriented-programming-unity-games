using UnityEngine;

public class Listener : MonoBehaviour
{
    int count;

    private void Start()
    {
        Invoker invoker = Camera.main.GetComponent<Invoker>();
        invoker.AddEventListener(PrintMessage);
    }

    void PrintMessage()
    {
        count++;

        print($"This is message No: {count}!");
    }
}
