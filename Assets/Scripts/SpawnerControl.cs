using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
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
            int rotateAngle = Random.Range(0, 360);
            _spawnerTransform[numberSpawner].Rotate(0, 0, rotateAngle, Space.Self);
            Instantiate(_enemyPrefab, _spawnerTransform[numberSpawner].position, _spawnerTransform[numberSpawner].rotation);
        }
    }
}
