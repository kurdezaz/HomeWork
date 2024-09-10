using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeView : View
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    public override void DisplayValue()
    {
        _textBarsAllObjects.text = _cubeSpawner.AllSpawnedCubes.ToString();
        _textBarsCreatedObjects.text = _cubeSpawner.CreatedObjects.ToString();
        _textBarsActiveObjects.text = _cubeSpawner.ActiveCubes.ToString();
    }
}
