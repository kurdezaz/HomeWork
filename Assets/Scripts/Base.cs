using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _countBots;
    [SerializeField] private float _radius;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private List<Resource> _resources = new List<Resource>();

    private List<Bot> _bots = new List<Bot>();

    private void Start()
    {
        CreateBots();
        ScaningResources();
    }

    private void Update()
    {
        SendBots();
    }

    public void PutBot(Bot bot)
    {
        _bots.Add(bot);
        bot.gameObject.SetActive(false);
    }

    private void CreateBots()
    {
        for (int i = 0; i < _countBots; i++)
        {
            var bot = Instantiate(_bot);
            bot.transform.position = gameObject.transform.position;
            _bots.Add(bot);
            bot.gameObject.SetActive(false);
        }
    }

    private void ScaningResources()
    {
        _colliders = Physics.OverlapSphere(gameObject.transform.position, _radius, _layerMask);

        foreach (var collider in _colliders)
        {
            collider.TryGetComponent(out Resource resource1);
            _resources.Add(resource1);
        }
    }

    private void SendBots()
    {
        if (_bots.Count > 0 && _resources.Count > 0)
        {
            var bot = _bots[0];
            var resource = _resources[0];

            _bots.Remove(bot);
            _resources.Remove(resource);

            bot.gameObject.SetActive(true);
            bot.GetPointDestination(resource.transform.position);
            bot.GetPointBase(transform.position);
            bot.GetResources(resource);
        }
    }
}
