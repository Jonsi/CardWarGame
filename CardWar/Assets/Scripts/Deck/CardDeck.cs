using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardDeck
{
    private List<PlacedCard> _items = new List<PlacedCard>();
    public int Count { get { return _items.Count; } }

    public void AddCard(PlacedCard card)
    {
        _items.Add(card);
    }

    public PlacedCard DrawItem()
    {
        if(_items.Count == 0)
        {
            return null;
        }
        var item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public PlacedCard Peek(bool includeFlips = false)
    {
        return _items.LastOrDefault(item => {
            if (includeFlips)
            {
                return true;
            }
            return !item.isFacingUp;
        });
    }
}
