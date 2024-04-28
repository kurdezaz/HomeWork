using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BarView : MonoBehaviour
{
    [SerializeField] protected ResourceCounter _playerResources;

    private void OnEnable()
    {
        _playerResources.Changed += DisplayValue;
    }

    private void OnDisable()
    {
        _playerResources.Changed -= DisplayValue;
    }

    public abstract void DisplayValue();
}
