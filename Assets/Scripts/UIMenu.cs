using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private TextMeshProUGUI _textBarsAllCubes;
    [SerializeField] private TextMeshProUGUI _textBarsAllBombs;
    [SerializeField] private TextMeshProUGUI _textBarsCreatedCubes;
    [SerializeField] private TextMeshProUGUI _textBarsCreatedBombs;
    [SerializeField] private TextMeshProUGUI _textBarsActiveCubes;
    [SerializeField] private TextMeshProUGUI _textBarsActiveBombs;

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
            DisplayValues();
        }
    }

    private void DisplayValues()
    {
        _textBarsAllCubes.text = _cubeSpawner.AllSpawnedCubes.ToString();
        _textBarsCreatedCubes.text = _cubeSpawner.CreatedObjects.ToString();
        _textBarsActiveCubes.text = _cubeSpawner.ActiveCubes.ToString();

        _textBarsAllBombs.text = _bombSpawner.AllSpawnedBombs.ToString();
        _textBarsCreatedBombs.text = _bombSpawner.CreatedObjects.ToString();
        _textBarsActiveBombs.text = _bombSpawner.ActiveBombs.ToString();
    }
}
