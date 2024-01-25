using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] private Spawner[] _enemySpawner;
    [SerializeField] private float _timeSpawn = 2f;

    private float _timer;

    private void Start()
    {
        _timer = _timeSpawn;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _timeSpawn;
             int numberEnemySpawner = Random.Range(0, _enemySpawner.Length);
            _enemySpawner[numberEnemySpawner].CreateEnemy();
        }
    }
}
