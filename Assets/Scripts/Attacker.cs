using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _vampiricDamage = 50;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private int _vampiricAttackCooldown = 6;

    private WaitForSeconds _wait;
    private Coroutine _attackCoroutine;

    private void Awake()
    {
        _wait = new WaitForSeconds(_attackCooldown);
    }

    public void StartAttack(Health health)
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(AttackDelay(health));
        }
    }

    public void StartVampiricAttack(Health health)
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(VampiricAttackDelay(health));
        }
    }

    private IEnumerator AttackDelay(Health health)
    {
        health.TakeDamage(_damage);
        yield return _wait;
        _attackCoroutine = null;
    }

    private IEnumerator VampiricAttackDelay(Health health)
    {
        int partialDamage = _vampiricDamage / _vampiricAttackCooldown;

        for (int i = 0; i <= _vampiricAttackCooldown; i++)
        {
            health.TakeDamage(partialDamage);
            _playerHealth.TakeHeal(partialDamage);
            yield return _wait;
        }

        _attackCoroutine = null;
    }
}
