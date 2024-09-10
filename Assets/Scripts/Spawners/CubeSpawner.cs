using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private BombSpawner _bombSpawner;

    private float _delay = 1f;

    public int AllSpawnedCubes { get; private set; }
    public int ActiveCubes { get; private set; }

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
        Cube cube = GetObject(_objectPool.ReturnQueue(), _cubePrefab);
        cube.Init(transform.position);
        cube.DiedEvent += PutCube;
        AllSpawnedCubes++;
        ActiveCubes++;
    }

    private void PutCube(Cube cubePrefab)
    {
        cubePrefab.DiedEvent -= PutCube;
        _bombSpawner.CreateBomb(cubePrefab.transform.position);
        ActiveCubes--;
        cubePrefab.gameObject.SetActive(false);
        _objectPool.PutObject(cubePrefab);
    }
}
