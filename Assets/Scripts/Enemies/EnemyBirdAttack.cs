using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdAttack : MonoBehaviour
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private EnemyBullerGenerator _enemyGenerator;
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

    private IEnumerator LaunchBullets()
    {
        var wait = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    public void StartAttack()
    {
        StartCoroutine(LaunchBullets());
    }

    public void Init(EnemyBullerGenerator bullerGenerator, ObjectPool objectPool,
        PlayerBulletGenerator playerBulletGenerator, Bird bird)
    {
        _enemyGenerator = bullerGenerator;
        _objectPool = objectPool;
        _playerGenerator = playerBulletGenerator;
        _bird = bird;
    }

    public void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _bullet = _enemyGenerator.GetBullet();
        _bullet.gameObject.SetActive(true);
        _bullet.transform.position = spawnPoint;
    }
}
