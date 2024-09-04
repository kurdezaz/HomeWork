using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
