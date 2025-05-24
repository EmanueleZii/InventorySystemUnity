using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting.Dependencies.NCalc;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Slider HealthBar;
    private bool inventory = true;
    [SerializeField]
    private GameObject zaino;

    public Text health_text;
    public float health = 100f;

    void Update()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
        HealthBar.value = health;
        health_text.text = health.ToString();
        LogicHealth();
        ZainoLogic();
    }
    private void LogicHealth()
    {
        if (health <= 0)
            health = 0;
        if (health >= 100)
            health = 100;
    }

    //zaino logic 

    private void ZainoLogic()
    {

        if (Input.GetKey("i") && inventory)
        {
             inventory = !inventory;
          zaino.SetActive(inventory);
        }
        else if (Input.GetKey("i") && inventory == false)
        {
            inventory = !inventory;
            zaino.SetActive(inventory);
        }
    }

    public void OnClick()
    { 
          inventory = !inventory;
          zaino.SetActive(inventory);
    }

}
