public interface ICardSlotController : IController<DeckItem>
{
    public Card GetSlotCard();
}