using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPills : MonoBehaviour
{
    [SerializeField] private int Health = 50;
    public int AmountHeal { get; private set; }

    private void Start()
    {
        AmountHeal = Health;
    }

    public void PickUp()
    {
        Destroy(gameObject);
    }
}
