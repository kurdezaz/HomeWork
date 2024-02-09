using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public float Volume { get; private set; }

    private void Update()
    {
        Volume = _audioSource.volume;
    }

    public void RunSound()
    {
        _audioSource.Play();
    }

    public void TurnOffSound()
    {
        _audioSource.Stop();
    }

    public void SetupVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
