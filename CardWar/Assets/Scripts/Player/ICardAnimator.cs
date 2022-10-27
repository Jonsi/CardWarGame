using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICardAnimator
{
    void MoveCard(PlacedCard card,ICardView source,ICardView destination,float? speed = null,Action onComplete = null);
}