using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatList))]
public class Inventory : MonoBehaviour
{
    private StatList statList;
    public List<ItemSlot> itemList = new List<ItemSlot>();

    private void Start()
    {
        statList = GetComponent<StatList>();
    }

    public void IncreaseItem(Item item)
    {
        ItemSlot slot = FindItemInList(item);
        if (slot == null)
        {
            slot = new ItemSlot(item);
            itemList.Add(slot);
        }
        else
        {
            slot.Increase();
        }
    }

    public void DecreaseItem(Item item)
    {
        ItemSlot slot = FindItemInList(item);
        if (slot == null) return;
        
        slot.Decrease();
        if (slot.count == 0) itemList.Remove(slot);
    }

    public void UseItem(Item item)
    {
        ItemSlot slot = FindItemInList(item);
        if (slot == null) return;

        slot.item.Use(statList);
        DecreaseItem(item);
    }

    public ItemSlot FindItemInList(Item item)
    {
        return itemList.Find(slot => slot.item == item);
    }
}
