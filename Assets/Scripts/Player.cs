using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private int _damage = 50;
    [SerializeField] private float _attackCooldown = 1f;

    private bool _isAttack = true;
    private WaitForSeconds _wait;
    private Coroutine _attackCoroutine;

    private void Start()
    {
        _wait = new WaitForSeconds(_attackCooldown);
    }

    private void Update()
    {
        if (_playerCollision.IsCollision && _isAttack)
        {
            StartAttack();
            _isAttack = false;
        }
    }

    private void StartAttack()
    {
        _attackCoroutine = StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return _wait;
        _playerCollision.EnemyHeal.TakeDamage(_damage);
        _isAttack = true;
    }
}
