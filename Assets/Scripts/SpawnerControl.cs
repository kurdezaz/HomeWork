using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private float _timeSpawn = 2f;
    [SerializeField] private Transform[] _spawnerTransform;
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
            int numberSpawner = Random.Range(0, _spawnerTransform.Length);
            int xVector = Random.Range(-10, 10);
            int yVector = Random.Range(-10, 10);
            Vector2 _enemyVector = new Vector2(xVector, yVector);
            Instantiate(_enemyPrefab, _spawnerTransform[numberSpawner].position, _spawnerTransform[numberSpawner].rotation).GetDirection(_enemyVector);
        }
    }
}
