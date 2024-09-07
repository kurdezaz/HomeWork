using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
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
        var cube = _cubePool.GetCube();
        cube.Init(transform.position);
        cube.Died += PutCube;
    }

    private void PutCube(Cube cube)
    {
        cube.Died -= PutCube;
        _cubePool.PutCube(cube);
    }
}
