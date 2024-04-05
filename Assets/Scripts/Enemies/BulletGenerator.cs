using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerGenerator : MonoBehaviour
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private EnemyBirdAttack _enemy;


    private Queue<EnemyBullet> _bulletPool;

    public IEnumerable<EnemyBullet> PooledEnemies => _bulletPool;

    private void Awake()
    {
        _bulletPool = new Queue<EnemyBullet>();

      //  StartCoroutine(LaunchBullets());
    }

     public EnemyBullet GetBullet()
     {
        // Debug.Log(_bulletPool.Count);
        /*
        var bullet = Instantiate(_bullet);

        return bullet;*/

          if (_bulletPool.Count == 0)
           {
               var bullet = Instantiate(_bullet);

               return bullet;
           }

           return _bulletPool.Dequeue();
    }

    

    public void PutBullet(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);

    }

    private IEnumerator LaunchBullets()
    {
        var wait = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            yield return wait;
            //Spawn();
            //_enemy.Spawn(GetBullet()) ;
        }
    }



    
    /*
    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _bullet = GetBullet();

        _bullet.gameObject.SetActive(true);
        _bullet.transform.position = _enemy.Location();
    }
    */

}
