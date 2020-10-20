using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    public Slider slider;
    public Image fill;

    private int currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
