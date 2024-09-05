using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _coefficient = 2;

    public float Probability { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Cube cube)
    {
        transform.localScale /= _coefficient;
        DivideChance(cube.Probability);
        transform.position = cube.transform.position;
    }
    
    private void DivideChance(float chance)
    {
        Probability = chance / _coefficient;
    }
}
