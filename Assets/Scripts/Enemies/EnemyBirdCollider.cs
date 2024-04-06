using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdCollider : MonoBehaviour
{
    [SerializeField] private PlayerBulletGenerator _playerGenerator;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private EnemyBirdAttack _enemyBird;
    [SerializeField] private Bird _bird;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerBullet bullet))
        {
            _playerGenerator.PutBullet(bullet);
            _objectPool.PutEnemy(_enemyBird);
            _bird.ScoreUp();
        }
    }

    public void Init(ObjectPool objectPool, PlayerBulletGenerator playerBulletGenerator, Bird bird)
    {
        _objectPool = objectPool;
        _playerGenerator = playerBulletGenerator;
        _bird = bird;
    }
}
