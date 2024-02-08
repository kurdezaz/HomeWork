using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;
    [SerializeField] private float _timeVolume = 0.5f;

    private WaitForSeconds _wait;
    private int _upOrDownAlarm = 1;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeVolume);
    }

    private IEnumerator AlarmDelay()
    {
        float number = 0;

        while (true)
        {
            yield return _wait;
            number += _upOrDownAlarm * 0.1f;
            _soundController.SetupVolume(Mathf.Clamp(number, 0, 1));
        }
    }

    public void ChangeDown()
    {
        _upOrDownAlarm = -1;
    }

    public void StartAlarm()
    {
        StartCoroutine(AlarmDelay());
    }
}
