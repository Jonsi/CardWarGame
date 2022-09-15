using UnityEngine;
using TMPro;

public class CardSlotView : MVCView<DeckItem>
{
    [SerializeField] private CardSuitSprites _cardSuitSprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshPro _kindText;
    public override void Set(DeckItem item)
    {
        base.Set(item);

        if (item == null || item.Card == null)
        {
            SetBlank();
            return;
        }

        if (item.IsFlipped)
        {
            SetFlipped();
            return;
        }
        SetView(item);
    }

    private void SetView(DeckItem item)
    {
        _spriteRenderer.sprite = _cardSuitSprites.GetSuitSprite(item.Card.Suit);

        if (item.Card.Kind < CardKind.J)
        {
            _kindText.text = ((int)item.Card.Kind).ToString();
        }
        else
        {
            _kindText.text = item.Card.Kind.ToString();
        }
    }

    private void SetFlipped()
    {
        _spriteRenderer.sprite = _cardSuitSprites.Flipped;
        _kindText.text = "";
    }

    private void SetBlank()
    {
        _spriteRenderer.sprite = _cardSuitSprites.Blank;
        _kindText.text = "";
    }
}
