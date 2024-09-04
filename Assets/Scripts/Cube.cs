using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _halfNumber = 2;

    public float Probability { get; private set; } = 100;

    public void HalveChance(float chance)
    {
        Probability = chance / _halfNumber;
    }
}
