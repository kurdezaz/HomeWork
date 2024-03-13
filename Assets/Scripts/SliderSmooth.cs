using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderSmooth : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Slider _sliderSmooth;
    [SerializeField] private float _timeSlider = 0.1f;

    private int _currentPlayerHealth = 0;
    private WaitForSeconds _wait;
    private Coroutine _sliderCoroutine;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeSlider);
        _currentPlayerHealth = _playerHealth.PlayerHealth;
        _sliderSmooth.minValue = _playerHealth.MinHealth;
        _sliderSmooth.maxValue = _playerHealth.MaxHealth;
    }

    private void Update()
    {
        _sliderSmooth.value = _currentPlayerHealth;

        if (_sliderCoroutine == null && _currentPlayerHealth != _playerHealth.PlayerHealth)
        {
            _sliderCoroutine = StartCoroutine(SliderDelay());
        }
        else if (_sliderCoroutine != null && _currentPlayerHealth == _playerHealth.PlayerHealth)
        {
            StopCoroutine(_sliderCoroutine);
            _sliderCoroutine = null;
        }
    }

    private IEnumerator SliderDelay()
    {
        while (_currentPlayerHealth != _playerHealth.PlayerHealth)
        {
            yield return _wait;

            if (_currentPlayerHealth > _playerHealth.PlayerHealth)
            {
                _currentPlayerHealth--;
            }
            else if (_currentPlayerHealth < _playerHealth.PlayerHealth)
            {
                _currentPlayerHealth++;
            }
        }
    }
}
