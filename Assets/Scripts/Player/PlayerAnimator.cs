using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string HorizontalMove = "HorizontalMove";
    private const string IsAttack = "IsAttack";

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
        _animator.SetFloat(HorizontalMove, Mathf.Abs(_playerInput.PlayerMovement));
       
        _spriteRenderer.flipX = _playerInput.PlayerMovement < 0;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _animator.SetBool(IsAttack, true);
        }
        else
        {
            _animator.SetBool(IsAttack, false);
        }
    }
}
