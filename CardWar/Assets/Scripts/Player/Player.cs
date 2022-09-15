using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;
public class Player : IPlayer
{
    private Deck _deck;
    private Deck _placedDeck;
    
    [Inject]
    private ICardSlotController _slotController;

    [Inject]
    private WorldEvent _worldEvent;

    public Player()
    {
        _deck = new Deck();
        _placedDeck = new Deck();
    }

    public void AddCard(Card card)
    {
        _deck.AddCard(card);
    }

    public Card DrawCard(bool flipped)
    {
        var deckItem = _deck.DrawItem();
        if(deckItem == null)
        {
            _worldEvent.OnPlayerDied(this);
            return null;
        }

        _placedDeck.AddCard(deckItem.Card,flipped);
        SyncVisual();
        return deckItem.Card;

    }

    public List<Card> TakePlacedCards()
    {
        var placedCards = new List<Card>();
        while (true)
        {
            var item = _placedDeck.DrawItem();
            if (item == null)
            {
                SyncVisual();
                return placedCards;
            }
            placedCards.Add(item.Card);
        }
    }

    private void SyncVisual()
    {
        var deckItem = _placedDeck.Peek(includeFlips: true);
        _slotController.Set(deckItem);
    }

}
