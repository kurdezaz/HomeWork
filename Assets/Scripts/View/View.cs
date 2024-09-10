using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class View : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _textBarsAllObjects;
    [SerializeField] protected TextMeshProUGUI _textBarsCreatedObjects;
    [SerializeField] protected TextMeshProUGUI _textBarsActiveObjects;

    private float _delay = 1f;

    private void Awake()
    {
        StartCoroutine(RunCounters());
    }

    private IEnumerator RunCounters()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            DisplayValue();
        }
    }

    public abstract void DisplayValue();
}
