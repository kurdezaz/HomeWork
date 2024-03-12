using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    [SerializeField] private TextMeshProUGUI _textBar;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _sliderSmooth;
    [SerializeField] private float _timeSlider = 0.1f;

    private WaitForSeconds _wait;
    private Coroutine _sliderCoroutine;
    private int maxHealth = 100;
    private int minHealth = 0;
    private int _currentHealth = 0;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeSlider);

        _slider.maxValue = maxHealth;
        _slider.minValue = minHealth;
        _sliderSmooth.maxValue = maxHealth;
        _sliderSmooth.minValue = minHealth;
        _currentHealth = _health;
    }

    private void Update()
    {
        _textBar.text = _health.ToString() +'/'+ maxHealth.ToString();
        _slider.value = _health;
        _sliderSmooth.value = _currentHealth;
        
        if (_sliderCoroutine == null && _currentHealth != _health)
        {
            _sliderCoroutine = StartCoroutine(SliderDelay());
        }
        else if (_sliderCoroutine != null && _currentHealth == _health)
        {
            StopCoroutine(_sliderCoroutine);
            _sliderCoroutine = null;
        }
    }

    private IEnumerator SliderDelay()
    { 
        while (_currentHealth != _health)
        {
            yield return _wait;

            if (_currentHealth > _health)
            {
                _currentHealth--;
            }
            else if (_currentHealth < _health)
            {
                _currentHealth++;
            }
        }

        
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, minHealth, maxHealth);
        Debug.Log(_health);
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(_health, minHealth, maxHealth);
        Debug.Log(_health);
    }
}
