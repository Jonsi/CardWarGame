using DG.Tweening;
using System.Collections;
using UnityEngine;


public class CardAnimator : MonoBehaviour,ICardAnimator
{
    [SerializeField] private SlotView _cardView;
    [SerializeField] private float _duration = 2f;
    public void MoveCard(PlacedCard card,ICardView source, ICardView destination)
    {
        _cardView.Set(card);
        _cardView.transform.position = source.Position;
        _cardView.transform.DOMove(destination.Position,_duration);
    }
}
