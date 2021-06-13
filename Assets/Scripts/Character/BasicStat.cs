using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicStat
{
    public StatType type;
    public Sprite sprite;

    [Range(0, 10)]
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

    public override string ToString()
    {
        return type + ": " + value;
    }
}

public enum StatType { Power, Corruption }
