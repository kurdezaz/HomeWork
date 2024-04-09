using UnityEngine;
using DG.Tweening;

public class CubeComplexMovevent : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private Vector3 _positionRotate;
    [SerializeField] private float _scaleCount;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOMove(_position.position, _duration).SetLoops(_repeats, _loopType);
        transform.DORotate(_positionRotate, _duration, RotateMode.FastBeyond360).SetLoops(_repeats, _loopType);
        transform.DOScale(_scaleCount, _duration).SetLoops(_repeats, _loopType);
    }
}
