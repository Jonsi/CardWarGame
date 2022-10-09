public interface ICardSlotController : IController<PlacedCard>
{
    public Card TakeCard();
}