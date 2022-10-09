using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Zenject;
using UnityEngine;

public class Player : IPlayer
{
    private CardDeck _placedCards;
    
    [Inject]
    private ICardSlotController _slotController;

    [Inject]
    private ICardDeckController _deckController;

    [Inject]
    private WorldEvent _worldEvent;

    [Inject(Id = "deck_view")]
    private ICardView _deckView;

    [Inject(Id = "slot_view")]
    private ICardView _slotView;

    [Inject]
    private ICardAnimator _cardAnimator;

    public Player()
    {
        _placedCards = new CardDeck();
    }

    public void AddCard(Card card)
    {
        _deckController.AddCard(card);
    }

    public Card PlaceCard(bool flipped)
    {
        var card = _deckController.DrawCard();
        if(card == null)
        {
            _worldEvent.OnPlayerDied(this);
            return null;
        }
        _cardAnimator.MoveCard(card,_deckView, _slotView);
        _placedCards.AddCard(card,flipped);
        _slotController.Set(card);
        return card;

    }

    public List<Card> TakePlacedCards()
    {
        var placedCards = new List<Card>();
        while (true)
        {
            var card = _placedCards.DrawItem();
            if (card == null)
            {
                return placedCards;
            }
            placedCards.Add(card);
            
        }
    }
}