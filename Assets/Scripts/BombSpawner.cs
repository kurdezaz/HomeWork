using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Exploder _exploder;

    private Queue<Bomb> _bombs;

    public int AllSpawnedBombs { get; private set; }
    public int ActiveBombs { get; private set; }

    private void Awake()
    {
        _bombs = new Queue<Bomb>();
    }

    public void CreateBomb(Vector3 position)
    {
        Bomb bomb = GetObject(_bombs, _bombPrefab);
        bomb.Init(position);
        bomb.DiedBomb += PutBomb;
        AllSpawnedBombs++;
        ActiveBombs++;
    }

    private void PutBomb(Bomb BombPrefab)
    {
        BombPrefab.DiedBomb -= PutBomb;
        _exploder.ExplodeAll(BombPrefab);
        ActiveBombs--;
        BombPrefab.gameObject.SetActive(false);
        _bombs.Enqueue(BombPrefab);
    }
}
