using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddListener(DestroyItem);
    }

    private void DestroyItem()
    {
        print("Destroying Test Object");

        Destroy(gameObject);
    }
}
