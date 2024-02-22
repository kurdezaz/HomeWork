using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    public float PlayerMovement { get; private set; }

    private void Start()
    {
        PlayerMovement = 0;
    }

    private void Update()
    {
        PlayerMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMovement.PressedSpace();
        }
    }
}
