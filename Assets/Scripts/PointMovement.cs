using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 0.5f;

    private int _currentWaypoint = 0;

    void Update()
    {
        Transform target = _waypoints[_currentWaypoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position,_speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            _currentWaypoint++;

            if (_currentWaypoint >= _waypoints.Length)
                _currentWaypoint = 0;
        }
    }
}
