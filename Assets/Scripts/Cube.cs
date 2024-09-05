using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float divider = 2;

    public float Probability { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void DivideChance(float chance)
    {
        Probability = chance / divider;
    }
}
