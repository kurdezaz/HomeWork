using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeal : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _heal = 10;

    public void MakeHeal()
    {
        _health.TakeHeal(_heal);
    }
}
