using System;
using System.Collections.Generic;

public interface IPlayer
{
    public void AddCard(Card card);
    public Card DrawCard(bool fliped);
    public List<Card> TakePlacedCards();
}