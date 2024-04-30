using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScaner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Base _base;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private List<Resource> _resources = new List<Resource>();

    public void ScaningResources()
    {
        _colliders = Physics.OverlapSphere(gameObject.transform.position, _radius, _layerMask);

        foreach (var collider in _colliders)
        {
            collider.TryGetComponent(out Resource resource1);
            _resources.Add(resource1);
        }

        _base.InitResources(_resources);
    }
}
