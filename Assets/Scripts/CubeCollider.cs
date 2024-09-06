using System.Collections;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private CubePool _cubePool;

    private MeshRenderer _meshRenderer;
    private bool _isCollisied = false;

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
                _meshRenderer.material.color = Random.ColorHSV();
                StartCoroutine(DieOnTime());
            }
        }
    }

    private IEnumerator DieOnTime()
    {
        float timeDelay = Random.Range(_cubePrefab.MinLifeTime, _cubePrefab.MaxLifeTime);
        var wait = new WaitForSeconds(timeDelay);

        while (enabled)
        {
            yield return wait;
            _meshRenderer.material.color = Color.white;
            _isCollisied = false;
            _cubePool.PutCube(_cubePrefab);
        }
    }

    public void Init(CubePool cubePool)
    {
        _cubePool = cubePool;
    }
}
