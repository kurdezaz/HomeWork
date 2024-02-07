using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timeVolume = 0.5f;

    private bool _isRobbed = false;
    private WaitForSeconds _wait;

    void Start()
    {
        _wait = new WaitForSeconds(_timeVolume);
    }

    private IEnumerator NonRobbedDelay()
    {
        while(_audioSource.volume < 1)
        {
            yield return _wait;
            _audioSource.volume += 0.1f;
        }

        _isRobbed = true;
        _player.ActivePlayer();
        StartCoroutine(RobbedDelay());
    }

    private IEnumerator RobbedDelay()
    {
        while (_audioSource.volume > 0)
        {
            yield return _wait;
            _audioSource.volume -= 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRobbed == false)
        {
            _audioSource.Play();
            _audioSource.volume = 0;
            StartCoroutine(NonRobbedDelay());
        }
    }
}
