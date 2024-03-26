using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BarView : MonoBehaviour
{
    [SerializeField] protected Health _unitHealth;

    private void OnEnable()
    {
        _unitHealth.Changed += DisplayValue;
    }

    private void OnDisable()
    {
        _unitHealth.Changed -= DisplayValue;
    }

    public abstract void DisplayValue();
}
