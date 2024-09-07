using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Queue<Cube> _cubes;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public Cube GetCube()
    {
        if (_cubes.Count == 0)
        {
            return Instantiate(_cubePrefab);
        }

        return _cubes.Dequeue();
    }

    public void PutCube(Cube cubePrefabs)
    {
        cubePrefabs.gameObject.SetActive(false);
        _cubes.Enqueue(cubePrefabs);
    }
}
