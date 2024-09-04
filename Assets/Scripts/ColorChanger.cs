using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = RandomColor();
    }

    Color RandomColor()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);
        float alfa = 1f;

        return new Color(red, green, blue, alfa);
    }
}
