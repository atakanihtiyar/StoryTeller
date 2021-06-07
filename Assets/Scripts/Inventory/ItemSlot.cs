using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int count = 1;

    public ItemSlot(Item newItem)
    {
        item = newItem;
        count = 1;
    }

    public void Increase()
    {
        count++;
    }

    public void Decrease()
    {
        if (count > 0)
        {
            count--;
        }
    }

    public override string ToString()
    {
        return item.name + " => " + count;
    }
}