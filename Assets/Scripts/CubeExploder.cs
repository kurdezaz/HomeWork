using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> rigidbodies, Vector3 transform)
    {
        foreach (Rigidbody explodableObject in ReturnRigidbodies(rigidbodies))
            explodableObject.AddExplosionForce(_explosionForce, transform, _explosionRadius);
    }

    private List<Rigidbody> ReturnRigidbodies(List<Rigidbody> outRigidbodies)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Rigidbody rigidbody in outRigidbodies)
            rigidbodies.Add(rigidbody);

        return rigidbodies;
    }
}
