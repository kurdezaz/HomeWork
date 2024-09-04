using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeExploder _cubeExploder;

    private List<Rigidbody> _explodableObjects = new List<Rigidbody>();

    private float _halfNumber = 2;
    private float _minCubesCount = 2;
    private float _maxCubesCount = 6;

    public void SpawnCubes(Vector3 scale, float chance, Vector3 transform)
    {
        _explodableObjects.Clear();

        for (int i = 1; i <= Random.Range(_minCubesCount, _maxCubesCount); i++)
        {
            CreateNewCube(scale,chance,transform);
        }
    }

    public List<Rigidbody> TransferExplodableObjects()
    {
        return _explodableObjects;
    }

    private void CreateNewCube(Vector3 scale, float chance, Vector3 transform)
    {
        Cube cube = Instantiate(_cube);

        cube.transform.localScale = scale / _halfNumber;
        cube.HalveChance(chance);
        cube.transform.position = transform;
        var clickHandler = cube.GetComponent<ClickHandler>();
        clickHandler.InitSpawner(this);
        clickHandler.InitExploder(_cubeExploder);

        _explodableObjects.Add(cube.ReturnRigidbody());
    }
}
