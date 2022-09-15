using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    private List<DeckItem> _items = new List<DeckItem>();

    public void AddCard(Card card, bool isFlipped = false)
    {
        _items.Add(new DeckItem(card, isFlipped));
    }

    public DeckItem DrawItem()
    {
        if(_items.Count == 0)
        {
            return null;
        }
        var item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public DeckItem Peek(bool includeFlips = false)
    {
        return _items.LastOrDefault(item => {
            if (includeFlips)
            {
                return true;
            }
            return !item.IsFlipped;
        });
    }
}
