using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    #region Singleton
    public static EventLogger Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    private Stack<Event> logs = new Stack<Event>();
    public Stack<Event> Logs { get => logs; }

    public void PushEvent(Event newEvent)
    {
        Logs.Push(newEvent);
    }

    public Event PopEvent()
    {
        return Logs.Pop(); 
    }
}
