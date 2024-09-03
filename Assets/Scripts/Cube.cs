using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;
    
    private float _minRandomValue = 0f;
    private float _maxRandomValue = 100f;

    private void OnMouseUpAsButton()
    {
        float chance = Random.Range(_minRandomValue, _maxRandomValue);

        if (chance <= _cubeSpawner.TransferProbability())
        {
            _cubeSpawner.SpawnCubes();
            _cubeExploder.Explode();
        }
        
        Destroy(gameObject);
    }

    public List<Rigidbody> TransferExplodableObjects()
    {
        return _cubeSpawner.TransferExplodableObjects();
    }
}
