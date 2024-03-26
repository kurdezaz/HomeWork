using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private const string IsAttack = "IsAttackEnemy";

    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Enemy _enemy;

    private SpriteRenderer _sprite;
    private Animator _animator;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _sprite.flipX = _enemyMovement.Distance.x < 0;

        if (Mathf.Abs(_enemyMovement.Distance.x) <= _enemyMovement.DistanceDestination && _enemy.IsPursuit)
        {
            _animator.SetBool(IsAttack, true);
        }
        else
        {
            _animator.SetBool(IsAttack, false);
        }
    }
}
