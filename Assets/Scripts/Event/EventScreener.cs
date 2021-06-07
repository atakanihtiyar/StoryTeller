using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScreener : MonoBehaviour
{
    public Image image;
    public Text narrator;
    public Text[] choiceTexts;

    public void UpdateUI(Event newEvent)
    {
        image.sprite = newEvent.GetImage();
        narrator.text = newEvent.GetDescription();
        SetChoiceTexts(newEvent.nextChoices);
    }

    public void SetChoiceTexts(Choice[] nextChoices)
    {
        for (int i = 0; i < choiceTexts.Length; i++)
        {
            SetActivateParent(choiceTexts[i], false);
            if (i < nextChoices.Length)
            {
                SetActivateParent(choiceTexts[i], true);
                choiceTexts[i].text = nextChoices[i].GetName();
            }
        }
    }

    public void SetActivateParent(Text choiceText, bool activate)
    {
        choiceText.transform.parent.gameObject.SetActive(activate);
    }
}
