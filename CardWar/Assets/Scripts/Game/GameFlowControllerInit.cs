using System.Collections.Generic;
using System;
using System.Linq;

public static class GameFlowControllerInit
{

    public static void InitGame(IPlayerManager playerManager)
    {

        //create 52 cards with cooresponding data

        var cardsList = CreateSortedCards();
        cardsList = cardsList.OrderBy(item => UnityEngine.Random.value).ToList();//shuffle
        for (int i = 0; i < cardsList.Count; i++)
        {
            playerManager.GetPlayer(i % playerManager.AllPlayers().Count).AddCard(cardsList[i]);
        }

    }

    private static List<Card> CreateSortedCards()
    {
        CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
        CardKind[] kinds = (CardKind[])Enum.GetValues(typeof(CardKind));

        List<Card> cards = new List<Card>();

        foreach (CardSuit suit in suits)
        {
            foreach (CardKind kind in kinds)
            {
                cards.Add(new Card(kind, suit));
            }
        }

        return cards;
    }
}