using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Bomb : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private float _lifeTime;
    private float _disappearingTimes = 10;
    private Color _baseColor;

    public event Action<Bomb> DiedEvent;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
        _lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DieOnTime());
        StartCoroutine(DisappearOnTime());
    }

    public void Init(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }

    private IEnumerator DisappearOnTime()
    {
        var wait = new WaitForSeconds(_lifeTime/_disappearingTimes);
        var color = _meshRenderer.material.color;

        while(enabled)
        {
            yield return wait;

            color.a -= 1/_disappearingTimes;
            color.a = Mathf.Clamp(color.a, 0, 1);
            _meshRenderer.material.color = color;
        }
    }

    private IEnumerator DieOnTime()
    {
        var wait = new WaitForSeconds(_lifeTime);

        yield return wait;
        _meshRenderer.material.color = _baseColor;
        DiedEvent?.Invoke(this);
    }
}
