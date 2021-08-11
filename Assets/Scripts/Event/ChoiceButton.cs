using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    TMP_Text tmp_Text;

    void OnEnable()
    {
        tmp_Text = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateText(string newString)
    {
        tmp_Text.text = newString;
    }

    public void SetActivate(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
