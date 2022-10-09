using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu]
public class CardSprites : ScriptableObject
{
    [SerializeField] private SpriteAtlas _spriteAtlas;

    [SerializeField] private Sprite _clubs;
    [SerializeField] private Sprite _diamonds;
    [SerializeField] private Sprite _hearts;
    [SerializeField] private Sprite _spades;
    [SerializeField] private Sprite _blank;
    [SerializeField] private Sprite _flipped;

    public Sprite Blank => _spriteAtlas.GetSprite(_blank.name);
    public Sprite BackSide => _spriteAtlas.GetSprite(_flipped.name);

    public Sprite GetSuitSprite(CardSuit cardSuit)
    {
        switch (cardSuit)
        {
            case CardSuit.Clubs:
                return _spriteAtlas.GetSprite(_clubs.name);
            case CardSuit.Diamonds:
                return _spriteAtlas.GetSprite(_diamonds.name);
            case CardSuit.Hearts:
                return _spriteAtlas.GetSprite(_hearts.name);
            case CardSuit.Spades:
                return _spriteAtlas.GetSprite(_spades.name);
            default:
                return _spriteAtlas.GetSprite(_blank.name);
        }
    }
}