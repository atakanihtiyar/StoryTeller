using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSlider : MonoBehaviour
{
    private Slider slider;
    public Image image;

    public void OnCreate()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateUI(Sprite sprite, int value)
    {
        slider.value = value;
        image.sprite = sprite;
    }
}
