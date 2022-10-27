public interface ICardDeckController : IController<CardDeck>
{
    void AddCard(PlacedCard card);
    PlacedCard DrawCard();
}