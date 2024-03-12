using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDamage : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _damage = 10;

    public void MakeDamage()
    {
        _health.TakeDamage(_damage);
    }
}
