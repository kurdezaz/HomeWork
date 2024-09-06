using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private bool _isCollisied = false;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;

    public event Action<Cube> Died;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isCollisied == false)
            {
                _isCollisied = true;
                _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
                StartCoroutine(DieOnTime());
            }
        }
    }

    private IEnumerator DieOnTime()
    {
        float timeDelay = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        var wait = new WaitForSeconds(timeDelay);

        yield return wait;
        _meshRenderer.material.color = Color.white;
        _isCollisied = false;
        Died?.Invoke(this);
    }
}
