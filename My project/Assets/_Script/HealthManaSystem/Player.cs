using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Slider HealthBar;

    public Text health_text;
    public float health = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    void Update()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
        HealthBar.value = health;
        health_text.text = health.ToString();
    }


}
