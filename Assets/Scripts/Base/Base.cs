using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private BotCreator _botCreator;

    [SerializeField] private int _countBots;
    [SerializeField] private float _radius;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private List<Resource> _resources = new List<Resource>();

    [SerializeField] private List<Bot> _bots = new List<Bot>();

    private void Start()
    {
       // ScaningResources();
    }

    private void Update()
    {
        SendBots();
        
    }

   /* public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }*/

    public void Init(List<Bot> bots)
    {
        Debug.Log("Peredano");
        _bots = bots;
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
       // Debug.Log(_bots.Count);
       // Debug.Log(_resources.Count);

        if (_botCreator.GetListBot().Count > 0 && _resources.Count > 0)
        {
            Debug.Log("Send");
            var bot = _botCreator.GetNumeredBot(0);
            var resource = _resources[0];

            //_bots.Remove(bot);
            _botCreator.DeleteBot(bot);
            _resources.Remove(resource);

            bot.gameObject.SetActive(true);
            bot.GetPointDestination(resource.transform.position);
            bot.GetPointBase(transform.position);
            bot.GetResources(resource);
        }
        else if (_botCreator.GetListBot().Count == _countBots && _resources.Count == 0)
        {
            Debug.Log("Scaning");
            ScaningResources();
        }
    }
}
