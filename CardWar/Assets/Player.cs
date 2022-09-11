using System.Collections;
using System.Collections.Generic;

public class Player : IPlayer
{
    private Deck _deck;
    private ICardSlotController _slotController;

    public Player()
    {
        _deck = new Deck();
    }

    public void AddCard(Card card)
    {
        _deck.AddCard(card);
    }
}
