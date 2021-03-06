﻿using UnityEngine;
using UnityEngine.UI;

namespace HealthBar
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(float maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        public void SetHealth(float health)
        {
            slider.value = health;
        }
    }
}