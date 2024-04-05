using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private PlayerBullet _playerBullet;
    [SerializeField] private PlayerBulletGenerator _bulletGenerator;

    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _handler;

    private float _delay = 0.5f;
    private Coroutine _attackCoroutine;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(GeneratePlayerBullets());
        }
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private IEnumerator GeneratePlayerBullets()
    {
        var wait = new WaitForSeconds(_delay);

        Spawn();
        yield return wait;
        _attackCoroutine = null;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Pipe)
        {
            GameOver?.Invoke();
        }

        else if(interactable is ScoreZone) 
        {
            _scoreCounter.Add();
        }
    }

    public void ScoreUp()
    {
        _scoreCounter.Add();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _playerBullet = _bulletGenerator.GetBullet();
        _playerBullet.gameObject.SetActive(true);
        _playerBullet.transform.position = spawnPoint;
    }
}
