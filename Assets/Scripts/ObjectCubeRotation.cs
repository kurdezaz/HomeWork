using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCubeRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, _rotateSpeed * Time.deltaTime);
    }
}
