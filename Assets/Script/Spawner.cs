using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnModes
{
    Fixed,
    Random
}

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SpawnModes spawnMode = SpawnModes.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private GameObject enemy;

    [Header("Fixed delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private float _spawnTimer;
    private int _enemiesSpawned;
    private ObjectPooler _pooler;

    private void Awake()
    {
        _pooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            if (_enemiesSpawned < enemyCount)
            {
                SpawnEnemy();
                _enemiesSpawned++;
            }
        }
    }

    private float GetSpawnDelay()
    {
        float time = 0f;
        switch (spawnMode)
        {
            case SpawnModes.Fixed:
                time = delayBtwSpawns;
                break;
            case SpawnModes.Random:
                time = GetRandomDelay();
                break;
            default:
                break;
        }
        return time;
    }
    private void SpawnEnemy()
    {
        GameObject newObject = _pooler.GetInstanceFromPool();
        newObject.SetActive(true);
    }
    private float GetRandomDelay() => Random.Range(minRandomDelay, maxRandomDelay);
}
