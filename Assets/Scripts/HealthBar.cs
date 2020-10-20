using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private int currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        SetHealth(currentHealth);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
