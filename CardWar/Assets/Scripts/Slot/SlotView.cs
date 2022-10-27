using UnityEngine;
using TMPro;

//TODO: MAKE CARD VIEW AND MAKE DECK VIEW INHERIT FRO IT
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
            ShowBlank();
            return;
        }

        if (card.isFacingUp == false)
        {
            ShowFlipped();
            return;
        }

        ShowCard(card);
    }

    private void ShowCard(PlacedCard card)
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

    private void ShowFlipped()
    {
        _spriteRenderer.sprite = _cardSuitSprites.BackSide;
        _kindText.text = "";
    }

    private void ShowBlank()
    {
        _spriteRenderer.sprite = _cardSuitSprites.Blank;
        _kindText.text = "";
    }
}
