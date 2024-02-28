using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public event Action Die;

    private int maxHealth = 100;
    private int minHealth = 0;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, minHealth, maxHealth);
        Debug.Log(_health);

        if (_health == 0)
        {
            Die?.Invoke();
        }
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(_health, minHealth, maxHealth);
    }
}
