using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardAnimator : MonoBehaviour,ICardAnimator
{
    [SerializeField] private List<SlotView> _availableSlotViews;//Change to pool
    [SerializeField] private float _defaultDuration = 2f;

    private void Start()
    {
        _availableSlotViews.ForEach(slotView => slotView.gameObject.SetActive(false));
    }

    public void MoveCard(PlacedCard card, ICardView source, ICardView destination,float? duration = null,Action OnComplete = null)
    {
        var slotView = _availableSlotViews.Take(1).FirstOrDefault();
        _availableSlotViews.Remove(slotView);
        if (slotView == null)
        {
            return;//TODO: Create from pool
        }

        slotView.gameObject.SetActive(true);
        slotView.Set(card);
        slotView.transform.position = source.Position;
        var tween = slotView.transform.DOMove(destination.Position, duration?? _defaultDuration);

        if(OnComplete != null)
        {
            tween.onComplete += () => OnComplete.Invoke();
        }
        tween.onComplete += () => OnAinmationComplete(slotView);
    }

    private void OnAinmationComplete(SlotView slotView)
    {
        slotView.gameObject.SetActive(false);
        _availableSlotViews.Add(slotView);
    }
}