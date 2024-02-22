using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 100;

    private int maxHealth = 100;
    private int minHealth = 0;
    
    public void TakeDamage(int damage)
    {
        _playerHealth -= damage;
        _playerHealth = Mathf.Clamp(_playerHealth, minHealth, maxHealth);
    }

    public void TakeHeal(int heal)
    {
        _playerHealth += heal;
        _playerHealth = Mathf.Clamp(_playerHealth, minHealth, maxHealth);
    }
}
