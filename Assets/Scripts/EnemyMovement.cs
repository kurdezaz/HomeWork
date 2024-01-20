using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _movementSpeed = 0.5f;

    private void Update()
    {
        transform.Translate(Vector2.one * _movementSpeed * Time.deltaTime);
    }
}
