using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool IsCollision { get; private set; } = false;
    public EnemyHealth EnemyHeal { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            EnemyHeal = enemy;
            IsCollision = true;
        }
        else
        {
            IsCollision = false;
        }
    }
}
