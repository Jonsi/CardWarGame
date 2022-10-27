using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlot : MonoBehaviour
{

    [SerializeField] private CardSlotController _slotController;
    public CardSlotController SlotController { get { return _slotController; } }

    [SerializeField] private DeckController _deckController;
    public DeckController DeckController { get { return _deckController; } }
    [SerializeField] private DeckView _deckView;
    public DeckView DeckView { get { return _deckView; } }

    [SerializeField] private SlotView _slotView;
    public SlotView SlotView { get { return _slotView; } }
}

