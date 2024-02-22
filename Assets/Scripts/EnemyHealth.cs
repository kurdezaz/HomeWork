using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _enemyHealth = 100;

    private int maxHealth = 100;
    private int minHealth = 0;

    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
        _enemyHealth = Mathf.Clamp(_enemyHealth, minHealth, maxHealth);
        Debug.Log(_enemyHealth);
    }

    private void Update()
    {
        if (_enemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
