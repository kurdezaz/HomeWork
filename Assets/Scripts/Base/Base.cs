using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private BotCreator _botCreator;
    [SerializeField] private ResourceScaner _resourceScaner;

    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private List<Bot> _bots = new List<Bot>();

    private void Update()
    {
        SendBots();
    }

    public void InitBots(List<Bot> bots)
    {
        _bots = bots;
    }

    public void InitResources(List<Resource> resources)
    {
        _resources = resources;
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
        else if (_bots.Count == _botCreator.CountBots && _resources.Count == 0)
        {
            _resourceScaner.ScaningResources();
        }
    }
}
