using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;

public class GameFlowController : MonoBehaviour
{
    [Inject]
    private IPlayerManager _playerManager;
    
    private void Start()
    {
        GameFlowControllerInit.InitGame(_playerManager);
        GameLoop().Forget();
    }

    private async UniTask GameLoop()
    {
        while (true)
        {
            while (_playerManager.AlivePlayers().Count > 1)
            {
                var round = new Round(_playerManager);
                round.Draw(fliped: false); // all draws a card. each player should have two decks.dw
                await UniTask.Delay(1000);
                var winner = round.CheckForWinner();
                if (winner != null)
                {
                    HandleSmallWin(winner);
                    await UniTask.Delay(1000);
                    continue;
                }
                round.Draw(fliped: true);
                await UniTask.Delay(1000);

            }

            if (_playerManager.AlivePlayers().Count == 0)
                tie();
            else
                win();
         }
    }

    private void win()
    {
        throw new NotImplementedException();
    }

    private void tie()
    {
        throw new NotImplementedException();
    }

    private void HandleSmallWin(IPlayer winner)
    {
        var players = _playerManager.AllPlayers();
        List<Card> placedCards = new List<Card>();
        foreach(IPlayer player in players)
        {
            placedCards.AddRange(player.TakePlacedCards());
        }

        //toDo shuffle cards
        foreach(var card in placedCards)
        {
            winner.AddCard(card);
        }
    }
}