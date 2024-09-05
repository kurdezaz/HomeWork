using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeNewCubes(List<Rigidbody> rigidbodies, Vector3 explosionPosition)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
            explodableObject.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }

    public void ExplodeAll(Cube cube)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(
                CalculateExplosionForce(cube, explodableObject), 
                cube.transform.position,
                CalculateExplosionRadius(cube));
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    private float CalculateExplosionForce(Cube cube, Rigidbody rigidbody)
    {
        float explosionForce = _explosionForce;
        float length = (cube.transform.position - rigidbody.transform.position).magnitude;
        explosionForce -= length;
        explosionForce /= cube.transform.localScale.magnitude;

        return explosionForce;
    }

    private float CalculateExplosionRadius(Cube cube)
    {
        float explosionRadius = _explosionRadius;
        explosionRadius /= cube.transform.localScale.magnitude;

        return explosionRadius;
    }
}
