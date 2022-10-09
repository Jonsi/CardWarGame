public class PlacedCard : Card
{
    public readonly bool IsFlipped;

    public PlacedCard(Card card,bool isFlipped) : base(card.Kind,card.Suit)
    {
        IsFlipped = isFlipped;
    }
}
