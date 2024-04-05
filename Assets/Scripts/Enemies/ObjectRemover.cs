using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private BullerGenerator _poolBullets;
    [SerializeField] private EnemyBirdAttack _poolEnemies;
    [SerializeField] private EnemyBullet _poolBullet;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBirdAttack enemy))
        {
            _pool.PutEnemy(enemy);
        }

        if (other.TryGetComponent(out EnemyBullet bullet))
        {
            _poolBullets.PutBullet(bullet);
            
        }

    }
}
