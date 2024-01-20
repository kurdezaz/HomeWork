using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _movementSpeed = 0.1f;
    private Vector2 _movementDirection;

    private void Update()
    {
        transform.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
    }

    public void SetupDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
