using UnityEngine;
using UnityEngine.UI;

public class EffectsButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _effect;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickOnEffect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickOnEffect);
    }

    private void ClickOnEffect()
    {
        _effect.Play();
    }
}
