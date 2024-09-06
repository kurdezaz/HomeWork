using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public float MinLifeTime { get; private set; } = 2f;
    public float MaxLifeTime { get; private set; } = 5f;
}
