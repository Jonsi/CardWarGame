using System.Collections;
using System.Collections.Generic;

public class Deck
{
    private Queue<Card> _cards = new Queue<Card>();

    public void AddCard(Card card)
    {
        _cards.Enqueue(card);
    }
}
