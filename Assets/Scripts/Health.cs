using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int UnitHealth { get; private set; } = 100;
    public int MaxHealth { get; private set; } = 100;
    public int MinHealth { get; private set; } = 0;

    public event Action Die;
    public event Action Changed;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            UnitHealth -= damage;
            UnitHealth = Mathf.Clamp(UnitHealth, MinHealth, MaxHealth);

            Changed?.Invoke();
        }
        
        if (UnitHealth == 0)
        {
            Die?.Invoke();
        }
    }

    public void TakeHeal(int heal)
    {
        if (heal >0)
        {
            UnitHealth += heal;
            UnitHealth = Mathf.Clamp(UnitHealth, MinHealth, MaxHealth);

            Changed?.Invoke();
        }
    }
}
