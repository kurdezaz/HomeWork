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
    }

    private void Update()
    {
        _slider.value = _playerHealth.PlayerHealth;
    }
}
