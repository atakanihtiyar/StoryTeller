using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Event", menuName = "Story Teller/Inventory Event")]
public class InventoryEvent : Event
{
    // itemsToUse boş o da 
    public override Event GetNextEvent(int index)
    {
        return base.GetNextEvent(index);
    }

    public override string[] GetChoiceTexts()
    {
        Inventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        string[] choiceTexts = new string[playerInventory.itemList.Count + 1];
        choiceTexts[0] = nextChoices[0].GetName();
        for (int i = 1; i <= playerInventory.itemList.Count; i++)
        {
            if (playerInventory.itemList[i - 1].count > 0)
            {
                choiceTexts[i] = playerInventory.itemList[i - 1].ToString();
                Choice choice = new Choice(choiceTexts[i], playerInventory.itemList[i - 1].item.GetUseEvent());
                nextChoices.Add(choice);
            }
        }
        return choiceTexts;
    }
}
