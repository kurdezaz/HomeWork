using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _halfNumber = 2;

    public float Probability { get; private set; } = 100;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody ReturnRigidbody()
    {
        return _rigidbody;
    }

    public void HalveChance(float chance)
    {
        Probability = chance / _halfNumber;
    }
}
