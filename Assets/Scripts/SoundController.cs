using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void RunSound()
    {
        _audioSource.Play();
    }

    public void SetupVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
