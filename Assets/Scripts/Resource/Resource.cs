using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceCounter _resourceCounter;

    private bool _isCarried;
    private Vector3 _botPosition;

    private void Update()
    {
        if (_isCarried)
        {
            transform.position = _botPosition;
        }
    }

    public void SetupResourcePosition(Vector3 botPosition)
    {
        _botPosition = botPosition;
        _isCarried = true;
    }

    public void Init(ResourceCounter resourceCounter)
    {
        _resourceCounter = resourceCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Base home))
        {
            _resourceCounter.TakeResource();
            gameObject.SetActive(false);
        }
    }
}
