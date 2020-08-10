using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    
    public void setMaxHealth(double health)
    {
        slider.maxValue = (float) health;
        slider.value = (float) health;
    }

    public void setHealth(double health)
    {
        slider.value = (float) health;
    }

}
