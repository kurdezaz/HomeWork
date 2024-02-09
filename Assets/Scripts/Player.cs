using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 0.3f;

    private int _currentWaypoint = 0;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Transform target = _waypoints[_currentWaypoint];
        float distanceDestination = 0.2f;
        Vector2 distance = transform.position - target.position;

        if (distance.x < 0) 
        {
            _sprite.flipX = false;
        }
        else
        {
            _sprite.flipX = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

         if (Vector2.Distance(transform.position, target.position) <= distanceDestination)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }
    }
}
