public class DeckItem
{
    public readonly bool IsFlipped;
    public readonly Card Card;

    public DeckItem(Card card,bool isFlipped)
    {
        IsFlipped = isFlipped;
        Card = card;
    }
}
