using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Attacker _enemyAttack;
    [SerializeField] private Health _enemyHealth;
    
    public bool IsPursuit { get; private set; } = false;
    public Health PlayerHealth { get; private set; }

    private void OnEnable()
    {
        _enemyHealth.Die += DieEnemy;
    }

    private void OnDisable()
    {
        _enemyHealth.Die -= DieEnemy;
    }

    private void Update()
    {
        if (Mathf.Abs(_enemyMovement.Distance.x) <= _enemyMovement.DistanceDestination && IsPursuit)
        {
            _enemyAttack.StartAttack(PlayerHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            IsPursuit = true;
        }

        if (collision.gameObject.TryGetComponent(out Health playerHealth))
        {
            PlayerHealth = playerHealth;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            IsPursuit = false;
        }
    }

    private void DieEnemy()
    {
        Destroy(gameObject);
    }
}
