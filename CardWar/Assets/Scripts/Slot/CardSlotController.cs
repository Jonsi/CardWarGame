using UnityEngine;

public class CardSlotController : MVCController<SlotView, PlacedCard>, ICardSlotController
{
    public Card TakeCard()
    {
        return Data;
    }
}