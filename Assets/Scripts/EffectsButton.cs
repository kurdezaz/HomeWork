using UnityEngine;
using UnityEngine.UI;

public class EffectsButton : MonoBehaviour
{
    [SerializeField] private AudioClips _audioMixer;
    [SerializeField] private Button _button;

    [SerializeField] private int _numberEffect;

    private void Awake()
    {
        _button.onClick.AddListener(ClickOnEffect);
    }

    private void ClickOnEffect()
    {
        _audioMixer.PlayEffect(_numberEffect);
    }
}
