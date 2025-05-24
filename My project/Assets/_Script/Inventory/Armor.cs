using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Armor", menuName = "Inventory/Armor")]
public class Armor : Item
{
    Player player;
    string nameArmor;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindAnyObjectByType<Player>();
    }
    
    public override void Use(Player player)
    {
        Debug.Log($"Hai equipaggiato una armatura {nameArmor}");
    }
}
