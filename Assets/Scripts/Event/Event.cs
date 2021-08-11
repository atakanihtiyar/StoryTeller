using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "StoryTeller/Event")]
public class Event : ScriptableObject
{
    public string description;
    public bool isEnd;
    public Choice[] nextChoices;

    public string GetDescription()
    {
        return description;
    }

    public void OnEnter()
    {
        if (isEnd)
            GameController.Instance.state = GameState.End;
    }

    public void OnRewind()
    {
        if (!isEnd)
            GameController.Instance.state = GameState.Play;
    }

    public Event OnExit(int selectedChoiceIndex)
    {
        return nextChoices[selectedChoiceIndex].GetNextEvent();
    }
}