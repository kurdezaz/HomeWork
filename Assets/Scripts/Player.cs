using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _waypointHome;
    [SerializeField] private Transform _waypointOut;
    [SerializeField] private float _speed = 0.5f;

    private bool _isHome = false;
    private Transform _target;

    private void Start()
    {
        _target = _waypointHome;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHome == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void ActivePlayer()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        _target = _waypointOut;
        _isHome = true;
    }
}
