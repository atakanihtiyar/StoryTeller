using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public string description;
    public Sprite sprite;
    public bool isEnd;
    public Choice[] nextChoices;

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
        if (isEnd)
            GameController.Instance.state = GameState.End;
    }

    public virtual void OnRewind()
    {

    }

    public virtual void OnExit(int selectedChoiceIndex)
    {

    }

    public virtual Event GetChoiceAt(int selectedChoiceIndex)
    {
        return nextChoices[selectedChoiceIndex].GetNextEvent();
    }

    public virtual string[] GetChoiceTexts()
    {
        string[] choiceTexts = new string[nextChoices.Length];
        for (int i = 0; i < nextChoices.Length; i++)
        {
            choiceTexts[i] = nextChoices[i].GetName();
        }
        return choiceTexts;
    }

    public virtual void SetNextChoices()
    {

    }
}