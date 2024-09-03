using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = RandomColor();
    }

    Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        float a = 1f;

        return new Color(r, g, b, a);
    }
}
