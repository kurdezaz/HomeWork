using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBar : BarView
{
    [SerializeField] private TextMeshProUGUI _textBar;

    private void Start()
    {
        _textBar.text = _playerResources.ResourceCount.ToString();
    }

    public override void DisplayValue()
    {
        _textBar.text = _playerResources.ResourceCount.ToString();
    }
}
