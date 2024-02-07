using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SoundController _soundController;
    [SerializeField] private float _timeVolume = 0.5f;

    private bool _isRobbed = false;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeVolume);
    }

    private IEnumerator RobberyDelay()
    {
        for (float i = 0; i <= 1.1; i += 0.1f) 
        {
            yield return _wait;
            _soundController.SetupVolume(i);
        }

        _isRobbed = true;
        _player.ActivePlayer();

        for (float i = 1; i >= -0.1; i -= 0.1f) 
        {
            yield return _wait;
            _soundController.SetupVolume(i);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRobbed == false)
        {
            _soundController.RunSound();
            _soundController.SetupVolume(0);
            StartCoroutine(RobberyDelay());
        }
    }
}
