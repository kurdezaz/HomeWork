using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;
    [SerializeField] private float _bottomBorder;
    [SerializeField] private float _upperBorder;

    private void Update()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(player.transform.position.x, _leftBorder, _rightBorder);
        playerPosition.y = Mathf.Clamp(player.transform.position.y, _bottomBorder, _upperBorder);
        playerPosition.z = transform.position.z;
        transform.position = playerPosition;
    }
}
