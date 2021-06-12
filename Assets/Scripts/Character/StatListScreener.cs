using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatListScreener : MonoBehaviour
{
    public StatList statList;
    public List<TMP_Text> tmpTexts;
    public GameObject tmpPrefab;

    private void Start()
    {
        for (int i = 0; i < statList.stats.Count; i++)
        {
            TMP_Text tmpText = Instantiate(tmpPrefab, transform).GetComponent<TMP_Text>();
            tmpText.text = statList.stats[i].value.ToString();
            tmpTexts.Add(tmpText);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < tmpTexts.Count; i++)
        {
            tmpTexts[i].text = statList.stats[i].ToString();
        }
    }
}
