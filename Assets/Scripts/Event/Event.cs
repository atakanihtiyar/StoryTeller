using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "StoryTeller/Event")]
public class Event : ScriptableObject
{
    public string description;
    public Sprite sprite;
    public bool isEnd;
    public BasicStat[] statModifiers;
    public BasicStat[] statFilters;
    public Choice[] nextChoices;

    public string GetDescription()
    {
        return description;
    }

    public Sprite GetImage()
    {
        return sprite;
    }

    public void OnEnter()
    {
        ApplyStats(1);

        if (isEnd)
            GameController.Instance.state = GameState.End;
    }

    public void OnRewind()
    {
        ApplyStats(-1);

        if (!isEnd)
            GameController.Instance.state = GameState.Play;
    }

    public Event OnExit(int selectedChoiceIndex)
    {
        return nextChoices[selectedChoiceIndex].GetNextEvent();
    }

    public bool PassFilter()
    {
        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();

        bool didPass = false;
        for (int i = 0; i < statFilters.Length; i++)
        {
            BasicStat playerStat = playerStatList.FindBasicStat(statFilters[i].type);
            if (playerStat.value > statFilters[i].value)
                didPass = true;
        }

        return didPass;
    }

    public void ApplyStats(int modifierMultiplier)
    {
        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();

        for (int i = 0; i < statModifiers.Length; i++)
        {
            playerStatList.UpdateStat(statModifiers[i].type, statModifiers[i].value * modifierMultiplier);
        }
    }
}