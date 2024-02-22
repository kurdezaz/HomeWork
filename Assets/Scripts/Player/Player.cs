using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private Attack _playerAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _playerCollision.IsCollision && _playerAttack.CanAttack)
        {
            if (_playerCollision.EnemyHeal != null)
            {
                _playerAttack.StartAttack(_playerCollision.EnemyHeal);
            }
        }
    }
}
