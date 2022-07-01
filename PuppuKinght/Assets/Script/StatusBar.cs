using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider;
    public float maxValue;
    public void SetMaxHealth(float hp)
    {
        slider.maxValue = maxValue;
        slider.value = hp;
    }

    public void SetHealth(float hp)
    {
        slider.value = hp;
    }
}
