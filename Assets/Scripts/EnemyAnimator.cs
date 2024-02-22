using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
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
        if (_enemyMovement.Distance.x < 0)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }

        if (Mathf.Abs(_enemyMovement.Distance.x) <= _enemyMovement.DistanceDestination && _enemy.IsPursuit)
        {
            _animator.SetBool("isAttack", true);
        }
        else
        {
            _animator.SetBool("isAttack", false);
        }
    }
}
