using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUper : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    private int _coins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coins++;
            coin.PickUp();
        }
        
        if (collision.gameObject.TryGetComponent(out MedPills medPills))
        {
            _playerHealth.TakeHeal(medPills.AmountHeal);
            medPills.PickUp();
        }
    }
}
