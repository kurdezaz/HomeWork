using UnityEngine;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private AudioMixerGroup _audioMixer;

    private string _masterVolume = "MasterVolume";
    private string _musicVolume = "MusicVolume";
    private string _effectVolume = "EffectsVolume";
    private float _maxLevelSound = 0;
    private float _minLevelSound = -80;
    private float _coefficient = 20;

    public void PlayEffect(int numberEffect)
    {
        _audioSources[numberEffect].Play();
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

    public void ChangeMasterVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(_masterVolume, CalculateVolume(volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(_musicVolume, CalculateVolume(volume));
    }

    public void ChangeEffectsVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(_effectVolume, CalculateVolume(volume));
    }

    private float CalculateVolume(float volume)
    {
        return Mathf.Log10(volume)*_coefficient;
    }
}
