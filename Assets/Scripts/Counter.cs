using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;

    public int Count { get; private set; }
    public bool IsButtonOn { get; private set; }

    public event Action Changed;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (IsButtonOn == false)
            {
                IsButtonOn = true;

                StartCoroutine(CounterActivate());
            }
            else
            {
                IsButtonOn = false;
            }
        }
    }

    private IEnumerator CounterActivate()
    {
        var wait = new WaitForSeconds(_delay);

        while (IsButtonOn)
        {
            yield return wait;
            Count++;
            Changed?.Invoke();
        }
    }
}
