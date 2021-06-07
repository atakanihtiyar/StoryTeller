using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicStat
{
    public StatType type;

    [Range(0, 5)]
    public int value = 0;

    public void AddValue()
    {
        value++;
    }

    public void RemoveValue()
    {
        value--;
    }

    public void AddValue(int modifier)
    {
        value += modifier;
    }

    public int GetValue()
    {
        return value;
    }
}

public enum StatType { Health, Power, Fearless }
