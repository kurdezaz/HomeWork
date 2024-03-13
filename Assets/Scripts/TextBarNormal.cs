using TMPro;
using UnityEngine;

public class TextBarNormal : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private TextMeshProUGUI _textBar;

    private void Update()
    {
        _textBar.text = _playerHealth.PlayerHealth.ToString() + '/' + _playerHealth.MaxHealth.ToString();
    }
}
