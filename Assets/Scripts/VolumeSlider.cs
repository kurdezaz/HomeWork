using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private TypeVolumes _typeVolumes;

    private float _coefficient = 20;

    enum TypeVolumes
    {
        MasterVolume = 0,
        MusicVolume,
        EffectsVolume
    }

    private void Awake()
    {
        _slider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(_typeVolumes.ToString(), CalculateVolume(volume));
    }

    private float CalculateVolume(float volume)
    {
        return Mathf.Log10(volume) * _coefficient;
    }
}
