using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSphereMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }
}
