using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private EnemyMovement _enemyMovement;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("HorizontalMove", Mathf.Abs(_playerInput.PlayerMovement));
        

        if (_playerInput.PlayerMovement < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        if (_playerCollision.IsCollision)
        {
            _animator.SetBool("IsAttack", true);
        }
        else
        {
            _animator.SetBool("IsAttack", false);
        }
    }

}
