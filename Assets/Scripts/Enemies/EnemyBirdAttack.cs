using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdAttack : MonoBehaviour
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private EnemyBullerGenerator _enemyGenerator;
    [SerializeField] private EnemyBirdAttack _enemyBird;

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

    public void Init(EnemyBullerGenerator bullerGenerator)
    {
        _enemyGenerator = bullerGenerator;
    }

    public void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _bullet = _enemyGenerator.GetBullet();
        _bullet.gameObject.SetActive(true);
        _bullet.transform.position = spawnPoint;
    }
}
