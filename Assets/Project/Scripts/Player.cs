using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _waypointHome;
    [SerializeField] private Transform _waypointOut;
    [SerializeField] private float _speed = 0.5f;
    
    private bool _isHome = false;
    
    void Update()
    {
        if (_isHome == false)
        {
            Transform target = _waypointHome;

            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }

        if (_isHome == true)
        {
            Transform target = _waypointOut;

            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
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
        _isHome = true;
    }
}
