using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private CubePool _cubePool;

    private float _delay = 1f;

    private void Awake()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            CreateCube();
        }
    }

    private void CreateCube()
    {
        float minRange = -6;
        float maxRange = 6;

        float randomizeX = Random.Range(minRange, maxRange);
        float randomizeZ = Random.Range(minRange, maxRange);
        var cube = _cubePool.GetCube(_cubePrefab);
        cube.gameObject.SetActive(true);
        cube.Init(_cubePool);
        cube.transform.position =
            new Vector3(transform.position.x + randomizeX, transform.position.y, transform.position.z + randomizeZ);
    }
}
