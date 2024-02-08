using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;
    [SerializeField] private float _timeVolume = 0.5f;

    private WaitForSeconds _wait;
    private int _changeVolumeAlarm = 1;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeVolume);
    }

    public void ChangeDown()
    {
        _changeVolumeAlarm = -1;
    }

    public void ChangeUp()
    {
        _changeVolumeAlarm = 1;
    }

    public void StartAlarm()
    {
        _soundController.RunSound();
        ChangeUp();
        StartCoroutine(AlarmDelay());
    }

    private IEnumerator AlarmDelay()
    {
        float volumeLevel = 0;

        while (true)
        {
            volumeLevel += _changeVolumeAlarm * 0.1f;
            volumeLevel = Mathf.Clamp(volumeLevel, 0, 1);
            _soundController.SetupVolume(volumeLevel);

            if (_soundController.GetVolumeLevel() == 0)
            {
                _soundController.TurnOffSound();
                StopCoroutine(AlarmDelay());
            }

            yield return _wait;
        }
    }
}
