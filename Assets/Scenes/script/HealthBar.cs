using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100;
    private void Start()
    {
        this.slider = gameObject.GetComponent<Slider>();
        this.SetMaxHealth(this.maxHealth);
    }

    public void SetMaxHealth(float health)
    {
        this.slider.maxValue = health;
        this.slider.value = health;
    }
    
    public void SetHealth(float health)
    {
        this.slider.value = health;
    }

    public float getNowHealthValue()
    {
        return this.slider.value;
    }
}
