using UnityEngine;
using DG.Tweening;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _scaleCount;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOScale(_scaleCount, _duration).SetLoops(_repeats, _loopType);
    }
}
