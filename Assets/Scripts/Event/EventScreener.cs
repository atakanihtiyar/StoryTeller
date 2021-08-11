using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventScreener : MonoBehaviour
{
    public TMP_Text narrator;
    private ChoiceButton[] choiceButtons;

    private void Awake()
    {
        choiceButtons = GetComponentsInChildren<ChoiceButton>();
    }

    public void UpdateUI(Event newEvent)
    {
        narrator.text = newEvent.GetDescription();
        SetChoiceTexts(newEvent.nextChoices);
    }

    public void SetChoiceTexts(Choice[] nextChoices)
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActivate(false);
            if (i < nextChoices.Length)
            {
                choiceButtons[i].SetActivate(true);
                choiceButtons[i].UpdateText(nextChoices[i].GetName());
            }
        }
    }
}
