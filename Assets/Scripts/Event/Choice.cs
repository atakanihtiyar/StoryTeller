using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice
{
    [TextArea] public string _name;
    public Event _nextEvent;

    public Choice(string name, Event nextEvent)
    {
        _name = name;
        _nextEvent = nextEvent;
    }

    public string GetName()
    {
        return _name;
    }

    public Event GetNextEvent()
    {
        return _nextEvent;
    }
}
