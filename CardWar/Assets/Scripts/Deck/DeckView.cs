using UnityEngine;
using TMPro;

public class DeckView : MVCView<CardDeck>,ICardView
{
    [SerializeField] private SpriteRenderer _deckSprite;
    [SerializeField] private TextMeshPro _countText;
    [SerializeField] private TextMeshPro _kindText;
    [SerializeField] private CardSprites _suitSprites;

    public Vector3 Position => _deckSprite.transform.position;

    public override void Set(CardDeck data)
    {
        base.Set(data);

        if (data == null || data.Count == 0)
        {
            _countText.text = "";
            ShowBlank();
            return;
        }

        _countText.text = data.Count.ToString();

        var topCard = data.Peek(includeFlips: true);
        if (topCard.isFacingUp)
        {
            ShowCard(topCard);
        }
        else
        {
            ShowFlipped();
        }

    }

    private void ShowCard(PlacedCard card)
    {
        _deckSprite.sprite = _suitSprites.GetSuitSprite(card.Suit);

        if (card.Kind < CardKind.J)
        {
            _kindText.text = ((int)card.Kind).ToString();
        }
        else
        {
            _kindText.text = card.Kind.ToString();
        }
    }

    private void ShowFlipped()
    {
        _deckSprite.sprite = _suitSprites.BackSide;
        _kindText.text = "";
    }

    private void ShowBlank()
    {
        _deckSprite.sprite = _suitSprites.Blank;
        _kindText.text = "";
    }
}