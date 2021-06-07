using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Story Event", menuName = "Story Teller/Story Event")]
public class StoryEvent : Event
{
    public BasicStat[] statModifiers;

    public override void OnEnter()
    {
        base.OnEnter();

        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();
        ApplyStats(playerStatList);
    }

    public override void OnRewind()
    {
        base.OnRewind();

        StatList playerStatList = GameObject.FindGameObjectWithTag("Player").GetComponent<StatList>();
        RewindStats(playerStatList);
    }

    public override Event OnExit(int selectedChoiceIndex)
    {
        return base.OnExit(selectedChoiceIndex);
    }

    public void ApplyStats(StatList statList)
    {
        for (int i = 0; i < statModifiers.Length; i++)
        {
            statList.UpdateStat(statModifiers[i].type, statModifiers[i].value);
        }
    }

    public void RewindStats(StatList statList)
    {
        for (int i = 0; i < statModifiers.Length; i++)
        {
            statList.UpdateStat(statModifiers[i].type, -statModifiers[i].value);
        }
    }

    public override string GetDescription()
    {
        return description;
    }
}