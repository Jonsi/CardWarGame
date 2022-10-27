using System.Data.Common;
using System.Runtime.CompilerServices;
using static UnityEditor.Progress;

public class DeckController : MVCController<DeckView, CardDeck>, ICardDeckController
{
    private void Awake()
    {
        Data = new CardDeck();
    }

    public PlacedCard DrawCard()
    {
        var item = Data.DrawItem();
        Set(Data);
        return item;
    }

    public void AddCard(PlacedCard card)
    {
        Data.AddCard(card);
        Set(Data);
    }
}
