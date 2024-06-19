using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _forceVector = new Vector3(0,0,10);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PushSwing()
    {
        _rigidbody.AddForce(_forceVector, ForceMode.Impulse);
    }
}
