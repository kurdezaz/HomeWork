using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private CubePool _cubePool;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private bool _isCollisied = false;

    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isCollisied == false)
            {
                _isCollisied = true;
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                StartCoroutine(DieOnTime());
            }
        }
    }

    private IEnumerator DieOnTime()
    {
        float timeDelay = Random.Range(_minLifeTime, _maxLifeTime);
        var wait = new WaitForSeconds(timeDelay);

        while (enabled)
        {
            yield return wait;
            GetComponent<MeshRenderer>().material.color = Color.white;
            _isCollisied = false;
            _cubePool.PutCube(this);
        }
    }

    public void Init(CubePool cubePool)
    {
        _cubePool = cubePool;
    }
}
