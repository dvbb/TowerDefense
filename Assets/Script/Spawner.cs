using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private float delayBtwWaves = 5f;

    [Header("Fixed delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private float _spawnTimer;
    private int _enemiesSpawned;
    private int _enemiesRemaining;

    private ObjectPooler _pooler;
    private Waypoint _waypoint;

    private void Awake()
    {
        _pooler = GetComponent<ObjectPooler>();
        _waypoint = GetComponent<Waypoint>();
        _enemiesRemaining = enemyCount;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            Debug.Log("2  ");
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

        Enemy enemy = newObject.GetComponent<Enemy>();
        if (enemy.moveState == null)
            enemy.InitEnemyComponent();
        enemy.Waypoint = _waypoint;
        enemy.ResetEnemy();
        //enemy.transform.position = _waypoint.Pointes[0] + _waypoint.CurrentPosition;

        newObject.SetActive(true);
    }
    private float GetRandomDelay() => Random.Range(minRandomDelay, maxRandomDelay);

    private IEnumerator NextWave()
    {
        Debug.Log("next wave");
        yield return new WaitForSeconds(delayBtwWaves);
        UIManager.Instance.UpdateWaves();
        _enemiesRemaining = enemyCount;
        _spawnTimer = 0;
        _enemiesSpawned = 0;
    }

    private void EnemyReachFinalPoint()
    {
        _enemiesRemaining--;
        if (_enemiesRemaining <= 0)
        {
            StartCoroutine("NextWave");
        }
    }

    public void RecordDeadEnemy()
    {
        _enemiesRemaining--;
        if (_enemiesRemaining <= 0)
        {
            StartCoroutine("NextWave");
        }
    }

    private void OnEnable()
    {
        Enemy.OnEndReached += EnemyReachFinalPoint;
        Enemy.OnDeadBeforeReached += RecordDeadEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= EnemyReachFinalPoint;
        Enemy.OnDeadBeforeReached -= RecordDeadEnemy;
    }
}
