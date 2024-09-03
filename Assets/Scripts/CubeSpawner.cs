using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private List<Rigidbody> _explodableObjects = new List<Rigidbody>();

    private float _probability = 100;
    private float _minCubesCount = 2;
    private float _maxCubesCount = 6;

    public void SpawnCubes()
    {
        for (int i = 1; i <= Random.Range(_minCubesCount, _maxCubesCount); i++)
        {
            CreateNewCube();
        }
    }

    public float TransferProbability()
    {
        return _probability;
    }

    public List<Rigidbody> TransferExplodableObjects()
    {
        return _explodableObjects;
    }

    private void CreateNewCube()
    {
        CubeSpawner cube = Instantiate(this);

        cube.gameObject.transform.localScale =
            new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        cube.HalveChance(_probability);
        cube.transform.position = transform.position;

        _explodableObjects.Add(cube.GetComponent<Rigidbody>());
    }

    private void HalveChance(float chance)
    {
        _probability = chance / 2;
    }
}
