using System;
using System.Collections.Generic;

public interface IPlayer
{
    public void AddCard(Card card);
    public Card PlaceCard(bool fliped);
    public List<Card> TakePlacedCards();
}