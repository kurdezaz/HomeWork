using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderSmooth : BaseClassView
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
        _maxChangeRate = _playerHealth.PlayerHealth;
        _currentPlayerHealth = _playerHealth.PlayerHealth;
        _sliderSmooth.minValue = _playerHealth.MinHealth;
        _sliderSmooth.maxValue = _playerHealth.MaxHealth;
        _sliderSmooth.value = _playerHealth.PlayerHealth;
    }

    public override void DisplayValue()
    {
        if (_sliderCoroutine == null && _currentPlayerHealth != _playerHealth.PlayerHealth)
        {
            _sliderCoroutine = StartCoroutine(SliderDelay());
        }
    }

    private IEnumerator SliderDelay()
    {
        float playerHealth = _playerHealth.PlayerHealth;

        while (_currentPlayerHealth != playerHealth)
        {
            yield return _wait;

            playerHealth = _playerHealth.PlayerHealth;
            float changeRate = Mathf.Abs(_currentPlayerHealth - playerHealth) / _healthChangeRate;
            changeRate = Mathf.Clamp(changeRate, _minChangeRate, _maxChangeRate);
            _currentPlayerHealth = Mathf.MoveTowards(_currentPlayerHealth, playerHealth, changeRate);
            _sliderSmooth.value = _currentPlayerHealth;
        }

        _sliderCoroutine = null;
    }
}
