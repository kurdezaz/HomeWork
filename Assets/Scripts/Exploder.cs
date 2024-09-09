using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeAll(Bomb explodeObject)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(explodeObject.transform.position))
            explodableObject.AddExplosionForce(_explosionForce, explodeObject.transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 explosionPoint)
    {
        Collider[] hits = Physics.OverlapSphere(explosionPoint, _explosionRadius);

        List<Rigidbody> explodeObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodeObjects.Add(hit.attachedRigidbody);

        return explodeObjects;
    }
}
