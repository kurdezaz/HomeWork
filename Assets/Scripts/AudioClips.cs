using UnityEngine;

public class AudioClips : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;

    public void PlayEffect(int numberEffect)
    {
        _audioSources[numberEffect].Play();
    }
}
