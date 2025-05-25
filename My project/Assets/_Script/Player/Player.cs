using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Slider HealthBar;
    public Slider Barrafame;
    private bool inventory = true;
    [SerializeField]
    private GameObject zaino;
    [SerializeField]
    private GameObject Equip;

    public Text health_text;
    public Text fame_text;
    public float health = 100f;
    public float fame = 90f;

    void Update()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
        HealthBar.value = health;
        health_text.text = health.ToString();
        fame_text.text = fame.ToString();
        Barrafame.minValue = 0;
        Barrafame.maxValue = 100;
        Barrafame.value = fame;
        LogicHealth();
        Logicfame();
        ZainoLogic();
    }
    private void LogicHealth()
    {
        if (health <= 0)
            health = 0;
        if (health >= 100)
            health = 100;
    }
    private void Logicfame()
    {
        if (fame <= 0)
            fame = 0;
        if (fame >= 100)
            fame = 100;
    }

    //zaino logic 

    private void ZainoLogic()
    {

        if (Input.GetKey("i") && inventory)
        {
            inventory = !inventory;
            zaino.SetActive(inventory);
            Equip.SetActive(inventory);
        }
        else if (Input.GetKey("i") && inventory == false)
        {
            inventory = !inventory;
            zaino.SetActive(inventory);
            Equip.SetActive(inventory);
        }
    }

    public void OnClick()
    {
        inventory = !inventory;
        zaino.SetActive(inventory);
        Equip.SetActive(inventory);
    }

}
