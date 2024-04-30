using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private int _resourceCount;
    [SerializeField] private ResourceCounter _resourceCounter;

    private void Awake()
    {
        float minRange = -4;
        float maxRange = 4;

        for (int i=0; i <= _resourceCount; i++)
        {
            float randomizeX = Random.Range(minRange,maxRange);
            float randomizeZ = Random.Range(minRange, maxRange);
            var resource = Instantiate(_resource);
            resource.transform.position =
                new Vector3(transform.position.x + randomizeX, transform.position.y, transform.position.z + randomizeZ);
        }
    }
}
