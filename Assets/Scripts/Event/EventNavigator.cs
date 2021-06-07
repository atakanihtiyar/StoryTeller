using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNavigator : MonoBehaviour
{
    public Event currentEvent;
    public EventScreener eventScreener;
    public StatListScreener statListScreener;

    private void Start()
    {
        eventScreener.UpdateUI(currentEvent);
        statListScreener.UpdateUI();
    }

    public void GoNextEvent(int selectedChoiceIndex)
    {
        EventLogger.Instance.PushEvent(currentEvent);
        currentEvent = currentEvent.OnExit(selectedChoiceIndex);
        currentEvent.OnEnter();
        eventScreener.UpdateUI(currentEvent);
        statListScreener.UpdateUI();
    }

    public void RewindButton()
    {
        if (EventLogger.Instance.Logs.Count == 0) return;

        currentEvent.OnRewind();
        Event oldEvent = EventLogger.Instance.PopEvent();
        currentEvent = oldEvent;
        eventScreener.UpdateUI(currentEvent);
        statListScreener.UpdateUI();
    }
}
