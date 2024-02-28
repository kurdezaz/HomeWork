using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPills : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] public int _amountHeal;

    public void PickUp()
    {
        _playerHealth.TakeHeal(_amountHeal);
        gameObject.SetActive(false);
    }
}
