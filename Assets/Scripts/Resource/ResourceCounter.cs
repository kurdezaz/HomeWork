using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    public event Action Changed;

    public int ResourceCount { get; private set; }

    public void TakeResource()
    {
        ResourceCount++;

        Changed?.Invoke();
    }

    public void CreateBot(int oneBotCost)
    {
        ResourceCount -= oneBotCost;
    }

    public void CreateBase(int oneBaseCost)
    {
        ResourceCount -= oneBaseCost;
    }
}
