using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private bool _isCollisied = false;
    private Color _colorWhite = Color.white;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;

    public event Action<Cube> DiedCube;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
        _meshRenderer.material.color = _colorWhite;
        _isCollisied = false;
        DiedCube?.Invoke(this);
    }

    public void Init(Vector3 vector3)
    {
        float minRange = -6;
        float maxRange = 6;

        float randomizeX = UnityEngine.Random.Range(minRange, maxRange);
        float randomizeZ = UnityEngine.Random.Range(minRange, maxRange);

        _meshRenderer.material.color = _colorWhite;
        gameObject.SetActive(true);
        transform.position = new Vector3(vector3.x + randomizeX, vector3.y, vector3.z + randomizeZ);
    }
}
