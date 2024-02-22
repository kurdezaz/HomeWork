using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;

    public bool CanAttack { get; private set; } = true;

    private WaitForSeconds _wait;
    private Coroutine _attackCoroutine;

    private void Start()
    {
        _wait = new WaitForSeconds(_attackCooldown);
    }

    public void StartAttack(Health health)
    {
        _attackCoroutine = StartCoroutine(AttackDelay(health));
        CanAttack = false;
    }

    private IEnumerator AttackDelay(Health health)
    {
        health.TakeDamage(_damage);
        yield return _wait;
        CanAttack = true;
    }
}
