public interface ICardDeckController : IController<CardDeck>
{
    void AddCard(Card card);
    PlacedCard DrawCard();
}