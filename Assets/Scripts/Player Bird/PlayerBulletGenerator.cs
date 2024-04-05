using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletGenerator : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bullet;

    private Queue<PlayerBullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Queue<PlayerBullet>();
    }

    public PlayerBullet GetBullet()
    {
        if (_bulletPool.Count == 0)
        {
            var bullet = Instantiate(_bullet);

            return bullet;
        }

        return _bulletPool.Dequeue();
    }

    public void PutBullet(PlayerBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}
