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
        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();
        ApplyStats(playerStatList, 1);

        if (isEnd)
            GameController.Instance.state = GameState.End;
    }

    public void OnRewind()
    {
        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();
        ApplyStats(playerStatList, -1);
    }

    public Event OnExit(int selectedChoiceIndex)
    {
        return nextChoices[selectedChoiceIndex].GetNextEvent();
    }

    public void ApplyStats(StatList statList, int modifierMultiplier)
    {
        for (int i = 0; i < statModifiers.Length; i++)
        {
            statList.UpdateStat(statModifiers[i].type, statModifiers[i].value * modifierMultiplier);
        }
    }
}