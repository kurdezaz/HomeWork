using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EnemyBirdAttack _enemyBird;
    [SerializeField] private EnemyInit _enemyInit;
    
    private void Start()
    {
        StartCoroutine(GeneratePipes());
    }

    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        _enemyBird = _pool.GetEnemy();
        _enemyBird.gameObject.SetActive(true);
        _enemyInit.Init(_enemyBird);
        _enemyBird.StartAttack();
        _enemyBird.transform.position = spawnPoint;
    }
}
