using UnityEngine;
using System.Collections.Generic;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;

    private int _clickRightMouseButton = 0;
    private float _minRandomValue = 0f;
    private float _maxRandomValue = 100f;
    private float _distance = 500;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_clickRightMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    float chance = Random.Range(_minRandomValue, _maxRandomValue);

                    if (chance <= cube.Probability)
                    {
                        List<Rigidbody> explodableObjects = _cubeSpawner.SpawnCubes(cube);

                        _cubeExploder.ExplodeNewCubes(explodableObjects, cube.transform.position);
                    }
                    else
                    {
                        _cubeExploder.ExplodeAll(cube);
                    }

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}
