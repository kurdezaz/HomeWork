using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * _speed * Time.deltaTime;

        _animator.SetFloat("HorizontalMove", Mathf.Abs(movement));

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y)< 0.05f)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        if (movement<0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
