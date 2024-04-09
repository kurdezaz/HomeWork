using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text1;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(GenerateText());
    }

    private IEnumerator GenerateText()
    {
        var wait = new WaitForSeconds(_delay);

        _text1.DOText("Privet!", _delay);
        yield return wait;
        _text1.DOText("Kak dela?", _delay).SetRelative();
        yield return wait;
        _text1.DOText("Ne rodila?", _delay, true, ScrambleMode.All);
    }
}
