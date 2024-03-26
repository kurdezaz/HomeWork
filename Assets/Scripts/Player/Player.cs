using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private PlayerCollision _playerSpecialCollision;
    [SerializeField] private Attacker _playerAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _playerCollision.IsCollision)
        {
            if (_playerCollision.EnemyHeal != null)
            {
                _playerAttack.StartAttack(_playerCollision.EnemyHeal);
            }
        }

        if (Input.GetKey("e") && _playerSpecialCollision.IsCollision)
        {
            if (_playerSpecialCollision.EnemyHeal != null)
            {
                _playerAttack.StartVampiricAttack(_playerSpecialCollision.EnemyHeal);
            }
        }
    }
}
