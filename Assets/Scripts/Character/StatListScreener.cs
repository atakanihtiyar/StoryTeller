using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatListScreener : MonoBehaviour
{
    public StatList statList;
    public Text[] texts;

    public void UpdateUI()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = statList.stats[i].ToString();
        }
    }
}
