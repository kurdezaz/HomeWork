using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in _cube.TransferExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
