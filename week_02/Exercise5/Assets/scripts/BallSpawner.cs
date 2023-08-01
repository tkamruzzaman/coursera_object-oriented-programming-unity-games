using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// Ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefabs;
    float spawnTimer;

    void Start()
    {
        spawnTimer = 1.0f;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0.0f)
        {
            spawnTimer = 1;

            SpawnRandomBall();
        }
    }

    void SpawnRandomBall()
    {
        if (ballPrefabs != null)
        {
            GameObject go = ballPrefabs[Random.Range(0, ballPrefabs.Length)];
            Instantiate(go, Vector3.zero, Quaternion.identity);
        }
    }
}