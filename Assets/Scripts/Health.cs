using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float PlayerHealth { get; private set; } = 100;

    public float MaxHealth { get; private set; } = 100;
    public float MinHealth { get; private set; } = 0;

    public event Action Changed;
   
    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            PlayerHealth -= damage;
            PlayerHealth = Mathf.Clamp(PlayerHealth, MinHealth, MaxHealth);

            Changed?.Invoke();
        }
    }

    public void TakeHeal(int heal)
    {
        if (heal > 0)
        {
            PlayerHealth += heal;
            PlayerHealth = Mathf.Clamp(PlayerHealth, MinHealth, MaxHealth);

            Changed?.Invoke();
        }
    }
}
