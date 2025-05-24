using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Slider HealthBar;

    private float health = 100f;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
        HealthBar.value = Health;
    }

  
    

}
