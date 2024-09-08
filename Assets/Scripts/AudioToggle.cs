using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Toggle _toggle;

    private float _maxLevelSound = 0;
    private float _minLevelSound = -80;

    private string _masterVolume = "MasterVolume";

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(ToggleAudio);
    }

    public void ToggleAudio(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.audioMixer.SetFloat(_masterVolume, _maxLevelSound);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_masterVolume, _minLevelSound);
        }
    }
}
