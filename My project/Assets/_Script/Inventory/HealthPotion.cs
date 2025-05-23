using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Potion", menuName = "Items/Healing Potion")]
public class HealthPotion : Item
{
    public int healAmount = 50;

    public override void Use()
    {
        Debug.Log($"Hai usato una pozione! Cura di {healAmount} HP.");
        // PlayerHealth.Instance.Heal(healAmount); // Esempio reale
    }
}
