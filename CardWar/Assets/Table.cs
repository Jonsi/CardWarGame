using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, ITable
{
    [SerializeField] private List<TableSlot> _slots;

    public TableSlot GetSlot(int index)
    {
        return _slots[index];
    }
}
