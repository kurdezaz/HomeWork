using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    
    private ResourceCounter _resourceCounter;
    private Base _newBase;
    private Base _base;
    private Resource _resource;
    private Flag _flag;
    private Vector3 _pointDestination;
    private Vector3 _pointBase;

    private bool _isCarry;
    private bool _isCreateNewBase;
    
    private void Update()
    {
        if (_isCarry == false && _isCreateNewBase == false)
        {
            MovePointDestination();
        }
        else if (_isCreateNewBase)
        {
            MovePointNewBase();
        }
        else
        {
            MovePointBase();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource) && _resource == resource)
        {
            resource.transform.position = this.transform.position;
            resource.transform.parent = this.transform;
            _isCarry = true;
        }

        if (other.TryGetComponent(out Base home) && _isCarry == true)
        {
            _isCarry = false;
            _resourceCounter.TakeResource();
            _resource.transform.parent = null;
            _resource.gameObject.SetActive(false);
            home.AddBot(this);
            gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out Flag flag) && _isCreateNewBase)
        {
            _isCreateNewBase = false;
            var basa = Instantiate(_newBase);
            basa.transform.position = transform.position;
            basa.AddBot(this);
            gameObject.SetActive(false);
            _base.OffActiveBase();
            _base.CloseOrderNewBase();
        }
    }

    public void Init(ResourceCounter resourceCounter)
    {
        _resourceCounter = resourceCounter;
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

    public void InitBase(Base base1)
    {
        _base = base1;
    }

    public void InitNewBase(Base newBase)
    {
        _newBase = newBase;
    }

    public void GetFlag (Flag flag)
    {
        _flag = flag;
    }

    public void OrderCreateNewBase()
    {
        _isCreateNewBase = true;
    }

    private void MovePointDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointDestination, _moveSpeed * Time.deltaTime);
    }

    private void MovePointNewBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _flag.transform.position, _moveSpeed * Time.deltaTime);
    }

    private void MovePointBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointBase, _moveSpeed * Time.deltaTime);
    }
}
