using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _jumpForce = 2f;

    private Rigidbody2D _rigidbody;

    private float _maxJumpSpeed = 0.05f;
    private float _maxRunSpeed = 5f;
    private float _runSpeed = 6f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.x) < _maxRunSpeed)
        {
            _rigidbody.velocityX = _playerInput.PlayerMovement * _runSpeed;
        }
    }

    public void PressedSpace()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < _maxJumpSpeed)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
}
