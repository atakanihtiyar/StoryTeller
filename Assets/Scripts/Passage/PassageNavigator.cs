using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PassageNavigator : MonoBehaviour
{
    public TextAsset jsonPath;

    public Passages rootOfPassages;
    public int currentIndex;

    public PassageScreener passageScreener;

    private void Start()
    {
        rootOfPassages = JsonUtility.FromJson<Passages>(jsonPath.text);

        currentIndex = rootOfPassages.passages.FindIndex(x => x.tags == "START");
        passageScreener.UpdateUI(rootOfPassages.passages[currentIndex]);
    }

    public void GoNextPassage(int selectedChoiceIndex)
    {
        PassageLogger.Instance.PushPassage(rootOfPassages.passages[currentIndex]);
        if (selectedChoiceIndex == 0)
        {
            int newIndex = rootOfPassages.passages.FindIndex(x => x.title == rootOfPassages.passages[currentIndex].to_name1);
            passageScreener.UpdateUI(rootOfPassages.passages[newIndex]);
            currentIndex = newIndex;
        }
        else if (selectedChoiceIndex == 1)
        {
            int newIndex = rootOfPassages.passages.FindIndex(x => x.title == rootOfPassages.passages[currentIndex].to_name2);
            passageScreener.UpdateUI(rootOfPassages.passages[newIndex]);
            currentIndex = newIndex;
        }

    }

    public void RewindButton()
    {
        if (PassageLogger.Instance.Logs.Count == 0) return;

        Passage oldPassage = PassageLogger.Instance.PopPassage();
        currentIndex = rootOfPassages.passages.IndexOf(oldPassage);
        passageScreener.UpdateUI(rootOfPassages.passages[currentIndex]);
    }
}
