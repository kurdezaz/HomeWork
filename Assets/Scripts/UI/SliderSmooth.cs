using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSmooth : BarView
{
    [SerializeField] private Slider _sliderSmooth;
    [SerializeField] private float _timeSlider = 0.1f;

    private float _healthChangeRate = 10f;
    private float _minChangeRate = 1f;
    private float _maxChangeRate;
    private float _currentPlayerHealth;
    private WaitForSeconds _wait;
    private Coroutine _sliderCoroutine;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeSlider);
        _maxChangeRate = _unitHealth.UnitHealth;
        _currentPlayerHealth = _unitHealth.UnitHealth;
        _sliderSmooth.minValue = _unitHealth.MinHealth;
        _sliderSmooth.maxValue = _unitHealth.MaxHealth;
        _sliderSmooth.value = _unitHealth.UnitHealth;
    }

    public override void DisplayValue()
    {
        if (_sliderCoroutine == null && _currentPlayerHealth != _unitHealth.UnitHealth)
        {
            _sliderCoroutine = StartCoroutine(SliderDelay());
        }
    }

    private IEnumerator SliderDelay()
    {
        float playerHealth = _unitHealth.UnitHealth;

        while (_currentPlayerHealth != playerHealth)
        {
            yield return _wait;

            playerHealth = _unitHealth.UnitHealth;
            float changeRate = Mathf.Abs(_currentPlayerHealth - playerHealth) / _healthChangeRate;
            changeRate = Mathf.Clamp(changeRate, _minChangeRate, _maxChangeRate);
            _currentPlayerHealth = Mathf.MoveTowards(_currentPlayerHealth, playerHealth, changeRate);
            _sliderSmooth.value = _currentPlayerHealth;
        }

        _sliderCoroutine = null;
    }
}
