using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAdjustments : MonoBehaviour
{
    [SerializeField]
    TypeOfSlider sliderType;
    [SerializeField]
    Slider slider;


    private void ChangeSliderValue(float obj, TypeOfSlider slidertype)
    {
        if (slidertype == sliderType)
            slider.value = obj;
    }
}
public enum TypeOfSlider
{
    Master,
    Music,
    SFX
}