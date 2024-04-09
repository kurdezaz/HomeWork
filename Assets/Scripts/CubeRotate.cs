using UnityEngine;
using DG.Tweening;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DORotate(_position, _duration, RotateMode.FastBeyond360).SetLoops(_repeats, _loopType);
    }
}
