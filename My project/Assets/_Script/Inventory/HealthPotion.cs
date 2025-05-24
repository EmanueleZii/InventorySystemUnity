using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Potion", menuName = "Items/Healing Potion")]
public class HealthPotion : Item 
{
    public int healAmount = 50;
    public Player player;

    void Start()
    {
        if (player == null)
           player = FindAnyObjectByType<Player>();
    }

    public override void Use(Player player)
    {
        if (player == null)
        {
            Debug.LogWarning("Player non assegnato.");
            return;
        }

        player.health += healAmount;
        Debug.Log($"Hai usato una pozione! Cura di {healAmount} HP.");
    }
}
