using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Slider HealthBar;

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
    }


}
