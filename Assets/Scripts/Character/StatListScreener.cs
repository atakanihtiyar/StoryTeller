using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatListScreener : MonoBehaviour
{
    public StatList statList;
    public TMP_Text[] texts;

    public void UpdateUI()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = statList.stats[i].ToString();
        }
    }
}
