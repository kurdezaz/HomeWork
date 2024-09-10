using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombView : View
{
    [SerializeField] private BombSpawner _bombSpawner;

    public override void DisplayValue()
    {
        _textBarsAllObjects.text = _bombSpawner.AllSpawnedBombs.ToString();
        _textBarsCreatedObjects.text = _bombSpawner.CreatedObjects.ToString();
        _textBarsActiveObjects.text = _bombSpawner.ActiveBombs.ToString();
    }
}
