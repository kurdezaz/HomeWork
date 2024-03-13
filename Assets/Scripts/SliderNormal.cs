using UnityEngine;
using UnityEngine.UI;

public class SliderNormal : BaseClassView
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _playerHealth.MaxHealth;
        _slider.minValue = _playerHealth.MinHealth;
        _slider.value = _playerHealth.PlayerHealth;
    }

    public override void DisplayValue()
    {
        float playerHealth = _playerHealth.PlayerHealth;
        _slider.value = playerHealth;
    }
}
