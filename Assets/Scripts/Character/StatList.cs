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

    public void UpdateStat(BasicStat modifier)
    {
        BasicStat stat = FindBasicStat(modifier.type);
        stat.value += modifier.value;
    }
}