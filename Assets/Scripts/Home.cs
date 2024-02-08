using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SoundController _soundController;
    [SerializeField] private Alarm _alarm;
    [SerializeField] private float _timeVolume = 6f;

    private bool _isRobbed = false;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeVolume);
    }

    private IEnumerator RobberyDelay()
    {
        yield return _wait;
        _isRobbed = true;
        _player.ActivePlayer();
        _alarm.ChangeDown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRobbed == false)
        {
            _soundController.RunSound();
            _soundController.SetupVolume(0);
            StartCoroutine(RobberyDelay());
            _alarm.StartAlarm();
        }
    }
}
