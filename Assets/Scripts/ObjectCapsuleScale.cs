using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCapsuleScale : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleDirection;
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        transform.localScale += _scaleDirection * _scaleSpeed * Time.deltaTime;
    }
}
