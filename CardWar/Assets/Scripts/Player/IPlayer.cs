using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

public interface IPlayer
{
    public void AddCard(PlacedCard card);
    public UniTask<PlacedCard> PlaceCard(bool facingUp);
    public List<PlacedCard> TakePlacedCards();
}