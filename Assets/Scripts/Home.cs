using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _alarm.StartAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _alarm.ChangeDown();
        }
    }
}
