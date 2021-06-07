using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatList : MonoBehaviour
{
    public List<BasicStat> stats;
    public List<BasicStat> Stats => stats;

    public BasicStat FindBasicStat(StatType type)
    {
        return Stats.Find(stat => stat.type == type);
    }

    public void UpdateStat(StatType modifierType, int modifierValue)
    {
        BasicStat stat = FindBasicStat(modifierType);
        stat.value += modifierValue;
    }
}