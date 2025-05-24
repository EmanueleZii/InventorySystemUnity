using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting.Dependencies.NCalc;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Slider HealthBar;

    public Text health_text;
    public float health = 100f;

    void Update()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
        HealthBar.value = health;
        health_text.text = health.ToString();
        LogicHealth();
    }
    private void LogicHealth()
    {
        if (health <= 0)
            health = 0;
        if (health >= 100)
            health = 100;
    }

}
