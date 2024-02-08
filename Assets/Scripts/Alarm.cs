using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SoundActivator _soundController;
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
        float volumeStep = 0.1f;
        float maxVolumelevel = 1;
        float minVolumeLevel = 0;

        while (true)
        {
            volumeLevel += _changeVolumeAlarm * volumeStep;
            volumeLevel = Mathf.Clamp(volumeLevel, minVolumeLevel, maxVolumelevel);
            _soundController.SetupVolume(volumeLevel);

            if (_soundController.GetVolumeLevel() == minVolumeLevel)
            {
                _soundController.TurnOffSound();
                StopCoroutine(AlarmDelay());
            }

            yield return _wait;
        }
    }
}
