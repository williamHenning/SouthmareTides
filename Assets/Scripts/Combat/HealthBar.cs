using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider; // Health bar
    public int maxHealth;
    public Gradient gradient;
    public Image fill;

    public void Start()
    {
        //fill = GetComponentsInChildren<Image>()[1];
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int maxHealth)
    {
        Debug.Log("Set max health " + maxHealth);
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }
}
