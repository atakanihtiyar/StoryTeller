using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventScreener : MonoBehaviour
{
    public TMP_Text narrator;
    public TMP_Text[] choiceTexts;

    public void UpdateUI(Event newEvent)
    {
        narrator.text = newEvent.GetDescription();
        SetChoiceTexts(newEvent.nextChoices);
    }

    public void SetChoiceTexts(Choice[] nextChoices)
    {
        for (int i = 0; i < choiceTexts.Length; i++)
        {
            SetActivateParent(choiceTexts[i], false);
            if (i < nextChoices.Length && nextChoices[i].GetNextEvent().PassFilter())
            {
                SetActivateParent(choiceTexts[i], true);
                choiceTexts[i].text = nextChoices[i].GetName();
            }
        }
    }

    public void SetActivateParent(TMP_Text choiceText, bool activate)
    {
        choiceText.transform.parent.gameObject.SetActive(activate);
    }
}
