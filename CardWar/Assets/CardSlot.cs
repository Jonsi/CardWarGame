using UnityEngine;

public class CardSlotController : MVCController<CardSlotView, Card>, ICardSlotController
{
    public void ShowCard(Card card)
    {
        Set(card);
    }
}

public class CardSlotView : MVCView<Card>
{

}

public interface ICardSlotController
{
    public void ShowCard(Card card);
}