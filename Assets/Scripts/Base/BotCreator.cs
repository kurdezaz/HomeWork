using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Base _base;
    [SerializeField] private ResourceCounter _resourceCounter;

    [SerializeField] private int _countBots;

    [SerializeField] private List<Bot> _bots = new List<Bot>();
    [SerializeField] private List<Bot> _bots2 = new List<Bot>();

    private void Start()
    {
        CreateBots();
        _bots2 = _bots;
        _base.Init(_bots);
    }

    public List<Bot> GetListBot()
    {
        return _bots;
    }

    public Bot GetNumeredBot(int number)
    {
        return _bots[number];
    }

    public void DeleteBot(Bot bot)
    {
        _bots.Remove(bot);
    }

    public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }

   /* public void PutBot(Bot bot)
    {
        _base.AddBot(bot);
        bot.gameObject.SetActive(false);
    }*/

    private void CreateBots()
    {
        for (int i = 0; i < _countBots; i++)
        {
            var bot = Instantiate(_bot);
            bot.transform.position = gameObject.transform.position;
            bot.Init(_resourceCounter);
            //_base.AddBot(bot);
            _bots.Add(bot);
            bot.gameObject.SetActive(false);
        }
    }
}
