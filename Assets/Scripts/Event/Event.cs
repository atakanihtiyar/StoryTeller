using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public string description;
    public Sprite sprite;
    public bool isEnd;
    public List<Choice> nextChoices;

    public virtual string GetDescription()
    {
        return description;
    }

    public virtual Sprite GetImage()
    {
        return sprite;
    }

    public virtual void OnEnter()
    {

    }

    public virtual Event OnExit(int selectedChoiceIndex)
    {
        return nextChoices[selectedChoiceIndex].GetNextEvent();
    }

    public virtual string[] GetChoiceTexts()
    {
        string[] choiceTexts = new string[nextChoices.Count];
        for (int i = 0; i < nextChoices.Count; i++)
        {
            choiceTexts[i] = nextChoices[i].GetName();
        }
        return choiceTexts;
    }

    public virtual void SetNextChoices()
    {

    }
}