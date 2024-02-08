using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 0.3f;

    private int _currentWaypoint = 0;

    private void Update()
    {
        Transform target = _waypoints[_currentWaypoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            _currentWaypoint++;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            if (_currentWaypoint >= _waypoints.Length)
            {
                _currentWaypoint = 0;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
