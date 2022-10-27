public class PlacedCard : Card
{
    public bool isFacingUp { get; private set; }

    public PlacedCard(CardKind kind,CardSuit suit, bool facingUp) : base(kind, suit)
    {
        isFacingUp = facingUp;
    }

    public void Flip(bool facingUp) => isFacingUp = facingUp;

}
