using UnityEngine;
using TMPro;

public class TextView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textView;

    private void OnEnable()
    {
        _counter.Changed += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayCount;
    }

    private void DisplayCount()
    {
        _textView.text = _counter.Count.ToString();
    }
}
