using TMPro;
using UnityEngine;

public class TextBarNormal : BaseClassView
{
    [SerializeField] private TextMeshProUGUI _textBar;

    private void Start()
    {
        _textBar.text = _playerHealth.PlayerHealth.ToString() + '/' + _playerHealth.MaxHealth.ToString();
    }

    public override void DisplayValue()
    {
        _textBar.text = _playerHealth.PlayerHealth.ToString() + '/' + _playerHealth.MaxHealth.ToString();
    }
}
