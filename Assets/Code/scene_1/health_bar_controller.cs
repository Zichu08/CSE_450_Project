using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_controller : MonoBehaviour {
    public Slider slider;
    public Gradient gradient; 
    public Image fill;

    public void set_max_health(int health) {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void set_health(int health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
