using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScheduler : MonoBehaviour
{
    [SerializeField] private Spawner[] _enemySpawner;
    [SerializeField] private float _timeSpawn = 2f;

    private float _timer;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeSpawn);
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while(true)
        {
            yield return _wait;
            int numberEnemySpawner = Random.Range(0, _enemySpawner.Length);
            _enemySpawner[numberEnemySpawner].CreateEnemy();
        }
    }
}
