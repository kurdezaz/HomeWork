using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPills : MonoBehaviour
{
    [field: SerializeField] public int AmountHeal { get; private set; }

    public void PickUp()
    {
        Destroy(gameObject);
    }
}
