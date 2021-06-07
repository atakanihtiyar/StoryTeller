using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNavigator : MonoBehaviour
{
    public Event currentEvent;
    public EventScreener screener;

    private void Start()
    {
        screener.UpdateUI(currentEvent);
    }

    public void GoNextEvent(int selectedChoiceIndex)
    {
        EventLogger.Instance.PushEvent(currentEvent);
        currentEvent = currentEvent.GetChoiceAt(selectedChoiceIndex);
        currentEvent.OnEnter();
        screener.UpdateUI(currentEvent);
    }

    public void RewindButton()
    {
        if (EventLogger.Instance.Logs.Count == 0) return;

        currentEvent.OnRewind();
        Event oldEvent = EventLogger.Instance.PopEvent();
        currentEvent = oldEvent;
        screener.UpdateUI(currentEvent);
    }
}
