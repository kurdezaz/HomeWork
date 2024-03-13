using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClassView : MonoBehaviour
{
    [SerializeField] protected Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Changed += DisplayValue;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= DisplayValue;
    }

    public abstract void DisplayValue();
}
