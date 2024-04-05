using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EnemyBullerGenerator _poolEnemyBullets;
    [SerializeField] private PlayerBulletGenerator _poolPlayerBullets;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBirdAttack enemy))
        {
            _pool.PutEnemy(enemy);
        }

        if (other.TryGetComponent(out EnemyBullet bullet))
        {
            _poolEnemyBullets.PutBullet(bullet);
        }

        if (other.TryGetComponent(out PlayerBullet playerBullet))
        {
            _poolPlayerBullets.PutBullet(playerBullet);
        }
    }
}
