using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private Queue<Cube> _cubePool;

    private void Awake()
    {
        _cubePool = new Queue<Cube>();
    }

    public Cube GetCube(Cube cubePrefab)
    {
        if (_cubePool.Count == 0)
        {
            return Instantiate(cubePrefab);
        }

        return _cubePool.Dequeue();
    }

    public void PutCube(Cube cubePrefabs)
    {
        cubePrefabs.gameObject.SetActive(false);
        _cubePool.Enqueue(cubePrefabs);
    }
}
