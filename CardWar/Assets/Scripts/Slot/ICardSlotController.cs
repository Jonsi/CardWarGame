public interface ICardSlotController : IController<PlacedCard>
{
    public PlacedCard TakeCard();
}