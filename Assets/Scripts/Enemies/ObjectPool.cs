using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private EnemyBirdAttack _enemyPrefab;

    private Queue<EnemyBirdAttack> _enemyPool;
   
    public IEnumerable<EnemyBirdAttack> PooledEnemies => _enemyPool;
   
    private void Awake()
    {
        _enemyPool = new Queue<EnemyBirdAttack>();
    }

    public EnemyBirdAttack GetEnemy()
    {
        if (_enemyPool.Count == 0)
         {
             var enemy = Instantiate(_enemyPrefab);

             return enemy;
         }

         return _enemyPool.Dequeue();
    }

    public void PutEnemy(EnemyBirdAttack enemy)
    {
        enemy.gameObject.SetActive(false);
        _enemyPool.Enqueue(enemy);
    }
}
