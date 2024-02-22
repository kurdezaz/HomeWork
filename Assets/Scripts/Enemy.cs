using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyMovement _enemyMovement;
    
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;

    public bool IsPursuit { get; private set; } = false;

    private bool _isAttack = true;
    private WaitForSeconds _wait;
    private Coroutine _attackCoroutine;

    private void Start()
    {
        _wait = new WaitForSeconds(_attackCooldown);
    }

    private void Update()
    {
        if (Mathf.Abs(_enemyMovement.Distance.x) <= _enemyMovement.DistanceDestination && IsPursuit && _isAttack)
        {
            StartAttack();
            _isAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            IsPursuit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            IsPursuit = false;
        }
    }

    private void StartAttack()
    {
        _attackCoroutine = StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return _wait;
        _playerHealth.TakeDamage(_damage);
        _isAttack = true;
    }
}
