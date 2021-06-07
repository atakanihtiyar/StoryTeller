using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNavigator : MonoBehaviour
{
    public Event currentEvent;

    public Image image;
    public Text narrator;
    public List<Text> choiceTexts;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        image.sprite = currentEvent.sprite;
        narrator.text = currentEvent.GetDescription();

        SetChoiceTexts();
    }

    public void SetChoiceTexts()
    {
        string[] choiceStrings = currentEvent.GetChoiceTexts();
        for (int i = 0; i < choiceTexts.Count; i++)
        {
            SetActivateParent(choiceTexts[i], false);
            if (i < choiceStrings.Length)
            {
                SetActivateParent(choiceTexts[i], true);
                choiceTexts[i].text = choiceStrings[i];
            }
        }
    }

    public void SetActivateParent(Text choiceText, bool activate)
    {
        choiceText.transform.parent.gameObject.SetActive(activate);
    }

    public void GetNextEvent(int selectedChoiceIndex)
    {
        Event newEvent = currentEvent.OnExit(selectedChoiceIndex);
        newEvent.OnEnter();
        IsGameEnd(newEvent);

        EventLogger.Instance.PushEvent(currentEvent);
        currentEvent = newEvent;

        UpdateUI();
    }

    public void IsGameEnd(Event newEvent)
    {
        if (currentEvent.isEnd)
            GameController.Instance.state = GameState.End;
    }

    public void RewindButton()
    {
        if (EventLogger.Instance.Logs.Count > 0)
        {
            currentEvent.OnRewind();
            Event oldEvent = EventLogger.Instance.PopEvent();
            currentEvent = oldEvent;
        }

        UpdateUI();
    }
}
