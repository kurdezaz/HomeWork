using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Transform _transformProjectile;
    [SerializeField] private Transform _startForcePoint;
    [SerializeField] private Transform _destinationForcePoint;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private ForcePoint _forcePoint;

    private float _delay = 3f;
    private bool _isReloaded;

    public void Fire()
    {
        _forcePoint.transform.position = _destinationForcePoint.position;
        _isReloaded = false;
    }

    public void Reload()
    {
        StartCoroutine(ReloadCatapult());
    }

    private IEnumerator ReloadCatapult()
    {
        var wait = new WaitForSeconds(_delay);

        if (_isReloaded != true)
        {
            _isReloaded = true;
            _forcePoint.transform.position = _startForcePoint.position;

            yield return wait;

            var projectile = Instantiate(_projectile);
            projectile.transform.position = _transformProjectile.position;
        }
    }
}
