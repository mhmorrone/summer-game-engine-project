using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    
    // Sets the slider to have a max health equal to 'health'
    public void setMaxHealth(double health)
    {
        slider.maxValue = (float) health;
        slider.value = (float) health;
    }

    // Sets the slider value to represent current health
    public void setHealth(double health)
    {
        slider.value = (float) health;
    }

}
