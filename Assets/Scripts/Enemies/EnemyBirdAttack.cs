using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdAttack : MonoBehaviour
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private BullerGenerator _generator;

    

   // public IEnumerable<EnemyBullet> PooledBullets => _bulletPool;

    private void Awake()
    {


    }

    private IEnumerator LaunchBullets()
    {
        var wait = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            yield return wait;
            Spawn();
            //_enemy.Spawn(GetBullet()) ;
        }
    }





    public void StartAttack()
    {
        StartCoroutine(LaunchBullets());
    }

    public void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _bullet = _generator.GetBullet();
        

        _bullet.gameObject.SetActive(true);
        _bullet.transform.position = spawnPoint;
    }

  /*  public Vector3 Location()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        return spawnPoint;
    }*/
}
