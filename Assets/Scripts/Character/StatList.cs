using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatList : MonoBehaviour
{
    public List<BasicStat> stats;

    public BasicStat FindBasicStat(StatType type)
    {
        return stats.Find(stat => stat.type == type);
    }
}