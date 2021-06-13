using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatListScreener : MonoBehaviour
{
    public StatList statList;
    public List<BasicSlider> sliders;
    public GameObject tmpPrefab;

    private void Start()
    {
        for (int i = 0; i < statList.stats.Count; i++)
        {
            BasicSlider basicSlider = Instantiate(tmpPrefab, transform).GetComponent<BasicSlider>();
            basicSlider.OnCreate();
            basicSlider.UpdateUI(statList.stats[i].sprite, statList.stats[i].value);
            
            sliders.Add(basicSlider);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            sliders[i].UpdateUI(statList.stats[i].sprite, statList.stats[i].value);
        }
    }
}
