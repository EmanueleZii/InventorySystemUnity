using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public string nomeArma = "";
    public int damage = 20;

    Player player;
    void Start() {
      if (player == null)
           player = FindAnyObjectByType<Player>();   
    }
    public override void Use(Player player)
    {
        Debug.Log($"Hai Equipagiato{nomeArma} con danno {damage}");
    }
}
