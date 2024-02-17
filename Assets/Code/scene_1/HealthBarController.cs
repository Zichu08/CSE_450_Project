using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=574s&ab_channel=Brackeys

    public Slider slider;
    public Gradient gradient; // BROKEN. trying to gradient color based on current health of player
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
