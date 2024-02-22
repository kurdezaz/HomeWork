using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private PlayerMovement _playerTransform;
    [SerializeField] private float _speed = 2f;

    public Vector2 Distance { get; private set; } = new Vector2(0, 0);
    public float DistanceDestination { get; private set; } = 1.2f;

    private Transform _target = null;
    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_enemy.IsPursuit)
        {
            _target = _playerTransform.transform;
        }
        else
        {
            _target = _waypoints[_currentWaypoint];
        }

        Distance = transform.position - _target.position;

        if (Mathf.Abs(Distance.x) <= DistanceDestination)
        {
            _currentWaypoint++;
            _currentWaypoint %= _waypoints.Length;
        }

        if (Mathf.Abs(Distance.x) >= DistanceDestination)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }
}
