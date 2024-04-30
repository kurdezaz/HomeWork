using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private int _resourceCount;
    [SerializeField] private int _resourcesPerDelay;
    [SerializeField] private float _delay;
    [SerializeField] private ResourceCounter _resourceCounter;

    private void Awake()
    {
        StartCoroutine(GenerateResources());

        Spawn(_resourceCount);
    }

    private IEnumerator GenerateResources()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn(_resourcesPerDelay);
        }
    }

    private void Spawn(int resourceCount)
    {
        float minRange = -4;
        float maxRange = 4;

        for (int i = 0; i < resourceCount; i++)
        {
            float randomizeX = Random.Range(minRange, maxRange);
            float randomizeZ = Random.Range(minRange, maxRange);
            var resource = Instantiate(_resource);
            resource.transform.position =
                new Vector3(transform.position.x + randomizeX, transform.position.y, transform.position.z + randomizeZ);
        }
    }
}
