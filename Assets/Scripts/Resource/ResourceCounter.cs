using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    public int ResourceCount { get; private set; }

    public event Action Changed;

    public void TakeResource()
    {
        ResourceCount++;

        Changed?.Invoke();
    }
}
