using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;


    private Vector3 flightPoint = new Vector3(-1, 0, 0);

    void Start()
    {

    }


    void Update()
    {
       transform.Translate(flightPoint.normalized * _bulletSpeed * Time.deltaTime);
    }
}
