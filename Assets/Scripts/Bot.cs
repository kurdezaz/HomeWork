using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Bot _bot;

    private Resource _resource;
    private Vector3 _pointDestination;
    private Vector3 _pointBase;

    private bool _isCarry;
    
    private void Update()
    {
        if (_isCarry == false)
        {
            MovePointDestination();
        }
        else
        {
            MovePointBase();
        }
    }

    public void GetPointDestination(Vector3 destination)
    {
        _pointDestination = destination;
    }

    public void GetPointBase(Vector3 pointBase)
    {
        _pointBase = pointBase;
    }

    public void GetResources(Resource resource)
    {
        _resource = resource;
    }

    private void MovePointDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointDestination, _moveSpeed * Time.deltaTime);
    }

    private void MovePointBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointBase, _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Resource resource) && _resource == resource)
        {
            resource.SetupResourcePosition(transform.position);
            _isCarry = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.TryGetComponent(out Base home) && _isCarry == true)
         {
             _isCarry = false;
             home.PutBot(_bot);
         }
    }
}
