using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassageScreener : MonoBehaviour
{
    public TMP_Text narrator;
    private ChoiceButton[] choiceButtons;

    private void Awake()
    {
        choiceButtons = GetComponentsInChildren<ChoiceButton>();
    }

    public void UpdateUI(Passage passage)
    {
        narrator.text = passage.text;

        choiceButtons[0].UpdateText(passage.answer1);

        if (passage.answer2 == "")
        {
            choiceButtons[1].SetActivate(false);
        }
        else
        {
            choiceButtons[1].SetActivate(true);
            choiceButtons[1].UpdateText(passage.answer2);
        }
    }
}
