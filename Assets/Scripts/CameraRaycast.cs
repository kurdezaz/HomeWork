using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Base _base;
    [SerializeField] private Transform _point;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distance;

    private Vector3 _flagPoint;
    private bool _isFlagStand;

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Vector3 startPosition = ray.origin;
        Vector3 endPosition = ray.direction.normalized;

        Debug.DrawRay(startPosition, endPosition * _distance, Color.black);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, _distance, _layerMask))
        {
            if (_base.IsActiveBase && _isFlagStand == false)
            {
                _point.position = hit.point;
            }
            else if (_base.IsActiveBase && _isFlagStand)
            {
                _point.position = _flagPoint;
            }
            else
            {
                _point.position = _base.gameObject.transform.position;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out Base base1))
                {
                    _base.OnActiveBase();
                }

                if (hit.collider.TryGetComponent(out WhiteTerrain terrain))
                {
                    _isFlagStand = true;
                    _flagPoint = hit.point;
                }
            }
        }
    }
}
