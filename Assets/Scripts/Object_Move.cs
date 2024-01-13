using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Move : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleDirection;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        transform.RotateAround(transform.position, transform.up, _rotateSpeed * Time.deltaTime);
        transform.localScale += _scaleDirection *_scaleSpeed * Time.deltaTime;
    }
}
