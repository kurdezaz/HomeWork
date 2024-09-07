using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Queue<Cube> _objectsPool;

    private void Awake()
    {
        _objectsPool = new Queue<Cube>();
    }

    public Cube GetCube()
    {
        if (_objectsPool.Count == 0)
        {
            return Instantiate(_cubePrefab);
        }

        return _objectsPool.Dequeue();
    }

    public void PutCube(Cube cubePrefabs)
    {
        cubePrefabs.gameObject.SetActive(false);
        _objectsPool.Enqueue(cubePrefabs);
    }
}
