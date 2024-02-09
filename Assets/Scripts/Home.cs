using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player) == _player.gameObject.TryGetComponent(out Player player1))
        {
            _alarm.StartAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) == _player.gameObject.TryGetComponent(out Player player1))
        {
            _alarm.ChangeDown();
        }
    }
}
