using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Player : IPlayer
{       
    private CardDeck _placedCards;

    [Inject]
    private TableSlot _tableSlot;

    [Inject]
    private ICardAnimator _cardAnimator;

    [Inject]
    private WorldEvent _worldEvent;

    public Player()
    {
        _placedCards = new CardDeck();
    }

    public void AddCard(PlacedCard card)
    {
        _tableSlot.DeckController.AddCard(card);
    }

    public async UniTask<PlacedCard> PlaceCard(bool facingUp)
    {
        var card = _tableSlot.DeckController.DrawCard();
        if (card == null)
        {
            _worldEvent.OnPlayerDied(this);
            return null;
        }

        card.Flip(facingUp);

        var animationComplete = new UniTaskCompletionSource();
        _cardAnimator.MoveCard(card, _tableSlot.DeckView, _tableSlot.SlotView, onComplete: () => { animationComplete.TrySetResult(); });
        await animationComplete.Task;
        _tableSlot.SlotController.Set(card);
        
        _placedCards.AddCard(card);
        return card;
    }

    public List<PlacedCard> TakePlacedCards()
    {
        var placedCards = new List<PlacedCard>();

        while (true)
        {
            var card = _placedCards.DrawItem();
            if (card == null)
            {
                break;
            }
            placedCards.Add(card);
        }

        _tableSlot.SlotController.Set(null);
        return placedCards;
    }
}