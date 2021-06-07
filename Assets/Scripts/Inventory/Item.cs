using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Story Teller/Item")]
public class Item : ScriptableObject
{
    public BasicStat statModifier;
    public Event useEvent;

    public void Use()
    {
        Debug.Log("Use: " + name + " item");
    }

    public void Use(StatList statList)
    {
        BasicStat statInList = statList.FindBasicStat(statModifier.type);
        statInList.AddValue(statModifier.value);
    }

    public Event GetUseEvent()
    {
        return useEvent;
    }
}
