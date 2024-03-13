using UnityEngine;
using UnityEngine.UI;

public class SliderNormal : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _playerHealth.MaxHealth;
        _slider.minValue = _playerHealth.MinHealth;
        _slider.value = _playerHealth.PlayerHealth;
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += DisplayValue;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= DisplayValue;
    }

    private void DisplayValue()
    {
        float playerHealth = _playerHealth.PlayerHealth;
        _slider.value = playerHealth;
    }
}
