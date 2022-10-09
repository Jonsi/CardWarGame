using UnityEngine;
using TMPro;

public class DeckView : MVCView<CardDeck>,ICardView
{
    [SerializeField] private SpriteRenderer _deckSprite;
    [SerializeField] private TextMeshPro _countText;
    [SerializeField] private CardSprites _suitSprites;

    public Vector3 Position => _deckSprite.transform.position;

    public override void Set(CardDeck data)
    {
        base.Set(data);

        _countText.text = data.Count.ToString();

        if (data.Count == 0)
        {
            _deckSprite.sprite = null;
            return;
        }

        _deckSprite.sprite = _suitSprites.BackSide;
    }
}