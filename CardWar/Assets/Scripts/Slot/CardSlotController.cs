using System.Runtime.CompilerServices;
using UnityEngine;

public class CardSlotController : MVCController<SlotView, PlacedCard>, ICardSlotController
{
    public PlacedCard TakeCard()
    {
        var data = Data;
        Set(null);
        return Data;
    }

}