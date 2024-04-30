using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Base _base;
    [SerializeField] private ResourceCounter _resourceCounter;

    [SerializeField] private List<Bot> _bots = new List<Bot>();

    [field: SerializeField] public int CountBots { get; private set; }

    private void Start()
    {
        CreateBots();
        _base.InitBots(_bots);
    }

    public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }
  
    private void CreateBots()
    {
        for (int i = 0; i < CountBots; i++)
        {
            var bot = Instantiate(_bot);
            bot.transform.position = gameObject.transform.position;
            bot.Init(_resourceCounter);
            _bots.Add(bot);
            bot.gameObject.SetActive(false);
        }
    }
}
