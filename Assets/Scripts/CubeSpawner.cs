using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private BombSpawner _bombSpawner;

    private float _delay = 1f;
    private Queue<Cube> _cubes;

    public int AllSpawnedCubes { get; private set; }
    public int ActiveCubes { get; private set; }

    private void Awake()
    {
        _cubes = new Queue<Cube>();
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
        Cube cube = GetObject(_cubes,_cubePrefab);
        cube.Init(transform.position);
        cube.DiedCube += PutCube;
        AllSpawnedCubes++;
        ActiveCubes++;
    }

    private void PutCube(Cube cubePrefab)
    {
        cubePrefab.DiedCube -= PutCube;
        _bombSpawner.CreateBomb(cubePrefab.transform.position);
        ActiveCubes--;
        cubePrefab.gameObject.SetActive(false);
        _cubes.Enqueue(cubePrefab);
    }
}
