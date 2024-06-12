using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _distance = new Vector3(0, 0, 0);
    private float _distanceDestination = 3f;
    private float _speed = 0.5f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
         _distance = _player.transform.position - transform.position;

        if (Mathf.Abs(_distance.x) >= _distanceDestination || Mathf.Abs(_distance.z) >= _distanceDestination)
        {
            _rigidbody.velocity = _distance * _speed;
        }
    }
}
