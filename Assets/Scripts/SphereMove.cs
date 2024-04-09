using UnityEngine;
using DG.Tweening;

public class SphereMove : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOMove(_position.position,_duration).SetLoops(_repeats,_loopType);
    }
}
