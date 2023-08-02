using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launcher Spawner 
/// </summary>
public class LauncherSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] launcherPrefabs;

    [SerializeField] float spawnSeconds = 5f;
    Timer spawnTimer;
    int spawnCount = 0;

    private void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnSeconds;
        spawnTimer.Run();
    }

    private void Update()
    {
        if (spawnTimer != null && spawnTimer.Finished && spawnCount < 3)
        {
            Instantiate(launcherPrefabs[spawnCount], 
                new Vector3(0,spawnCount,0), 
                Quaternion.identity);

            spawnCount++;
            spawnTimer.Run();
        }
    }

}
