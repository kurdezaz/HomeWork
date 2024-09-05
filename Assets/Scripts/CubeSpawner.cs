using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private float _halfNumber = 2;
    private float _minCubesCount = 2;
    private float _maxCubesCount = 6;

    public List<Rigidbody> SpawnCubes(Cube cube)
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        float randomNumber = Random.Range(_minCubesCount, _maxCubesCount);

        for (int i = 0; i < randomNumber; i++)
        {
            explodableObjects.Add(CreateNewCube(cube));
        }

        return explodableObjects;
    }

    private Rigidbody CreateNewCube(Cube cube)
    {
        Cube newCube = Instantiate(cube);

        newCube.transform.localScale /= _halfNumber;
        newCube.DivideChance(cube.Probability);
        newCube.transform.position = cube.transform.position;
        
        return newCube.Rigidbody;
    }
}
