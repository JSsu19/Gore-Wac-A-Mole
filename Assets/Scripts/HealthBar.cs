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
        SetMaxHealth(maxHealth); // Sätter healthen i början till max
    } 
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth; // Gör så att man kan kontrollera Max Value på healthbaren från scriptet istället för i Unity.
        slider.value = maxHealth; // I början sätter den slidern till max healthen.

        fill.color = gradient.Evaluate(1f); // Sätter färgen från gradient.
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // När man tar damage tas det ifrån currenthealth.
        slider.value = currentHealth; // Slidern uppdateras tillsammans med skadan.

        fill.color = gradient.Evaluate(slider.normalizedValue); // Omvandlar heltalen som hp scriptet ger till procenttal som fungerar för gradient.
    }
}
