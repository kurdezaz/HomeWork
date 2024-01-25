using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _movementSpeed = 0.5f;
    private Transform _pointDestination;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointDestination.position, _movementSpeed * Time.deltaTime);
    }

    public void SetupDestination(Transform transform)
    {
        _pointDestination = transform;
    }
}
