using UnityEngine;

public class CardSlotController : MVCController<CardSlotView, DeckItem>, ICardSlotController
{
    public Card GetSlotCard()
    {
        return Data.Card;
    }
}