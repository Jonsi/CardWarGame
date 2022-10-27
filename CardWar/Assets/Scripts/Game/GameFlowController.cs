using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;
using Cysharp.Threading.Tasks.Linq;
using System.Linq;
using ModestTree;
using System.Collections;

public class GameFlowController : MonoBehaviour
{
    [Inject]
    private IPlayerManager _playerManager;

    [Inject]
    private ICardAnimator _cardAnimator;

    [Inject(Id = "cards_stack")]
    private ICardView _cardsStackView;

    [Inject]
    private ICardDeckController _cardStack;

    [Inject]
    private Dictionary<IPlayer, TableSlot> _playerToSlot;

    [Range(0,5f)]
    [SerializeField] private float _gameSpeed = 1;
    private async void Start()
    {
        print("Initializing");//TODO: REMOVE
        await UniTask.Delay(2000);
        GameFlowControllerInit.InitGame(_playerManager);
        print("Starting Game");//TODO: REMOVE
        await UniTask.Delay(1000);
        GameLoop().Forget();
    }

    private async UniTask GameLoop()
    {
        while (true)
        {
            while (_playerManager.AlivePlayers().Count > 1)
            {
                var round = new Round(_playerManager);
                await round.Draw(facingUp: true);
                await UniTask.Delay(1000);
                var winner = round.CheckForWinner();
                if (winner != null)
                {
                    await HandleSmallWin(winner);
                    await UniTask.Delay(1000);
                    continue;
                }
                await round.Draw(facingUp: false);
                await UniTask.Delay(1000);

            }

            if (_playerManager.AlivePlayers().Count == 0)
                tie();
            else
                win();
        }
    }
    private void Update()
    {
        Time.timeScale = _gameSpeed;
    }
    private void win()
    {
        throw new NotImplementedException();
    }

    private void tie()
    {
        throw new NotImplementedException();
    }

    private async UniTask HandleSmallWin(IPlayer winner)
    {
        var players = _playerManager.AlivePlayers();

        foreach (IPlayer player in players)
        {
            var playerCards = player.TakePlacedCards();

            if(playerCards.Count == 0)
            {
                continue;
            }

            var playerSlot = _playerToSlot[player];

            var animationTasks = new List<UniTask>();
            foreach (var card in playerCards)
            {
                var animationCompleted = new UniTaskCompletionSource();
                animationTasks.Add(animationCompleted.Task);
                _cardAnimator.MoveCard(card, playerSlot.SlotView, _cardsStackView, 1f, onComplete:  () =>
                    {
                        _cardStack.AddCard(card);
                        animationCompleted.TrySetResult();
                    });

                 await UniTask.Delay(200);
            }

            await UniTask.WhenAll(animationTasks);
        }

        await UniTask.Delay(500);

        while (true)
        {
            //TODO: Shuffle Cards
            var card = _cardStack.DrawCard();
            if (card == null)
            {
                break;
            }
            var animationComplete = new UniTaskCompletionSource();
            _cardAnimator.MoveCard(card, _cardsStackView, _playerToSlot[winner].DeckView, 1f, onComplete: () => animationComplete.TrySetResult());
            await animationComplete.Task;
            card.Flip(facingUp: false);
            winner.AddCard(card);
            //TODO: add animation
        }
    }
}