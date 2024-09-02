using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private bool _isButtonOn;
    private int _count;

    public event Action<int> Changed;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_isButtonOn == false)
            {
                _isButtonOn = true;

                StartCoroutine(CounterActivate());
            }
            else
            {
                _isButtonOn = false;
            }
        }
    }

    private IEnumerator CounterActivate()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isButtonOn)
        {
            yield return wait;
            _count++;
            Changed?.Invoke(_count);
        }
    }
}
