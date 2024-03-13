using TMPro;
using UnityEngine;

public class TextBarNormal : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private TextMeshProUGUI _textBar;

    private void Start()
    {
        _textBar.text = _playerHealth.PlayerHealth.ToString() + '/' + _playerHealth.MaxHealth.ToString();
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += DisplayText;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= DisplayText;
    }

    private void DisplayText()
    {
        _textBar.text = _playerHealth.PlayerHealth.ToString() + '/' + _playerHealth.MaxHealth.ToString();
    }
}
