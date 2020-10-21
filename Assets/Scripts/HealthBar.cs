using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;

    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
