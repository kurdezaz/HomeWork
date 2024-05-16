using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Base _base;
    [SerializeField] private Base _newBase;
    [SerializeField] private ResourceCounter _resourceCounter;

    [SerializeField] private int _oneBotCost;
    [SerializeField] private int _countBots;

    [SerializeField] private List<Bot> _bots = new List<Bot>();

    private void Start()
    {
        CreateBots(_countBots);
    }

    public void CreateOneBot()
    {
        int oneBot = 1;

        if (_resourceCounter.ResourceCount >= _oneBotCost)
        {
            _resourceCounter.CreateBot(_oneBotCost);
            CreateBots(oneBot);
        }
    }

    private void CreateBots(int countBots)
    {
        for (int i = 0; i < countBots; i++)
        {
            var bot = Instantiate(_bot);
            bot.transform.position = gameObject.transform.position;
            bot.Init(_resourceCounter);
            bot.InitBase(_base);
            bot.InitNewBase(_newBase);
            _bots.Add(bot);
            _base.AddBot(bot);
            bot.gameObject.SetActive(false);
        }
    }
}
