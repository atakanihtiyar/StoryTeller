using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Story Event", menuName = "Story Teller/Story Event")]
public class StoryEvent : Event
{
    public Item[] itemsToAdd;
    public Item[] itemsToUse;

    public override Event GetNextEvent(int index)
    {
        Inventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        AddItemsToInventory(playerInventory);
        UseItemsFromInventory(playerInventory);

        return base.GetNextEvent(index);
    }

    public void AddItemsToInventory(Inventory inventory)
    {
        for (int i = 0; i < itemsToAdd.Length; i++)
        {
            inventory.IncreaseItem(itemsToAdd[i]);
        }
    }

    public void UseItemsFromInventory(Inventory inventory)
    {
        for (int i = 0; i < itemsToUse.Length; i++)
        {
            inventory.UseItem(itemsToUse[i]);
        }
    }

    public override string GetDescription()
    {
        return description;
    }
}