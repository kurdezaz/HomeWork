using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Flag _flag;
    [SerializeField] private BotCreator _botCreator;
    [SerializeField] private ResourceScaner _resourceScaner;
    [SerializeField] private ResourceCounter _resourceCounter;

    [SerializeField] private int _oneBaseCost;

    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private List<Bot> _bots = new List<Bot>();

    private bool _isOrderNewBase;
    
    public bool IsActiveBase { get; private set; }

    private void OnEnable()
    {
        _resourceCounter.Changed += CreateNewOne;
    }

    private void OnDisable()
    {
        _resourceCounter.Changed -= CreateNewOne;
    }

    private void Update()
    {
        SendBots();
    }

    public void InitBots(List<Bot> bots)
    {
        _bots = bots;
    }

    public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }

    public void AddResources(Resource resource)
    {
        _resources.Add(resource);
    }

    public void InitResources(List<Resource> resources)
    {
        _resources = resources;
    }

    public void OnActiveBase()
    {
        IsActiveBase = true;
    }

    public void OffActiveBase()
    {
        IsActiveBase = false;
    }

    public void CloseOrderNewBase()
    {
        _isOrderNewBase = false;
    }

    private void CreateNewOne()
    {
        if(IsActiveBase && _isOrderNewBase == false)
        {
            CreateBase();
        }
        else
        {
            _botCreator.CreateOneBot();
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
        else if (_resources.Count == 0)
        {
            _resourceScaner.ScaningResources();
        }
    }
    
    private void CreateBase()
    {
        if (_bots.Count > 0 && _resourceCounter.ResourceCount >= _oneBaseCost)
        {
            var bot = _bots[0];

            _bots.Remove(bot);
            bot.gameObject.SetActive(true);
            bot.GetFlag(_flag);
            bot.OrderCreateNewBase();
            bot.GetPointBase(transform.position);
            _isOrderNewBase = true;
            _resourceCounter.CreateBase(_oneBaseCost);
        }
    }
}
