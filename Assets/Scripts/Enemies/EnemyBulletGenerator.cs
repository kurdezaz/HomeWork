using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullerGenerator : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bullet;

    private Queue<EnemyBullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Queue<EnemyBullet>();
    }

     public EnemyBullet GetBullet()
     {
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
}
