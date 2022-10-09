using UnityEngine;
using TMPro;

public class SlotView : MVCView<PlacedCard>,ICardView
{
    [SerializeField] private CardSprites _cardSuitSprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshPro _kindText;

    public Vector3 Position => _spriteRenderer.transform.position;

    public override void Set(PlacedCard card)
    {
        base.Set(card);

        if (card == null)
        {
            SetBlank();
            return;
        }

        if (card.IsFlipped)
        {
            SetFlipped();
            return;
        }
        SetView(card);
    }

    private void SetView(PlacedCard card)
    {
        _spriteRenderer.sprite = _cardSuitSprites.GetSuitSprite(card.Suit);

        if (card.Kind < CardKind.J)
        {
            _kindText.text = ((int)card.Kind).ToString();
        }
        else
        {
            _kindText.text = card.Kind.ToString();
        }
    }

    private void SetFlipped()
    {
        _spriteRenderer.sprite = _cardSuitSprites.BackSide;
        _kindText.text = "";
    }

    private void SetBlank()
    {
        _spriteRenderer.sprite = _cardSuitSprites.Blank;
        _kindText.text = "";
    }
}
