using System.Collections;
using System.Collections.Generic;

public class Card
{
    public CardKind Kind { get; private set; }
    public CardSuit Suit { get; private set; }

    public Card(CardKind kind, CardSuit suit)
    {
        Kind = kind;
        Suit = suit;
    }

}

public static class CardUtils
{
    public static int Compare(Card A,Card B)
    {
        if(A == null)
        {
            return 1;
        }

        return A.Kind - B.Kind;
    }
}

public enum CardKind
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    J,
    Q,
    K,
    A,
}

public enum CardSuit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades,
}