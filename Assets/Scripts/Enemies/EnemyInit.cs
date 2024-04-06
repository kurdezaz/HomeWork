using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInit : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EnemyBirdAttack _enemyBird;
    [SerializeField] private PlayerBulletGenerator _playerGenerator;
    [SerializeField] private EnemyBullerGenerator _bullerGenerator;
    [SerializeField] private Bird _bird;

    public void Init(EnemyBirdAttack enemyBird)
    {
        enemyBird.TryGetComponent(out EnemyBirdCollider birdcollider);
        birdcollider.Init(_pool, _playerGenerator, _bird);
        enemyBird.Init(_bullerGenerator);
    }
}
