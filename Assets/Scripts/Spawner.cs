using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private Transform _spawnerTransform;
    [SerializeField] private Transform _pointDestination;

    public void CreateEnemy()
    {
        Instantiate(_enemyPrefab, _spawnerTransform.position, _spawnerTransform.rotation).SetupDestination(_pointDestination);
    }
}
