using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Story Event", menuName = "Story Teller/Story Event")]
public class StoryEvent : Event
{
    public override Event GetNextEvent(int index)
    {
        return base.GetNextEvent(index);
    }

    public override string GetDescription()
    {
        return description;
    }
}