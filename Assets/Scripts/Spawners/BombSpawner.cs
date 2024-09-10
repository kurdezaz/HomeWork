using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Exploder _exploder;

    public int AllSpawnedBombs { get; private set; }
    public int ActiveBombs { get; private set; }

    private void Awake(){}

    public void CreateBomb(Vector3 position)
    {
        Bomb bomb = GetObject(_objectPool.ReturnQueue(), _bombPrefab);
        bomb.Init(position);
        bomb.DiedEvent += PutBomb;
        AllSpawnedBombs++;
        ActiveBombs++;
    }

    private void PutBomb(Bomb bombPrefab)
    {
        bombPrefab.DiedEvent -= PutBomb;
        _exploder.ExplodeAll(bombPrefab);
        ActiveBombs--;
        bombPrefab.gameObject.SetActive(false);
        _objectPool.PutObject(bombPrefab);
    }
}
