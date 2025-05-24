using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public string nomeArma = "";
    public int damage = 20;

    public override void Use()
    {
        Debug.Log($"Hai usato{nomeArma} con danno {damage}");
    }
}
