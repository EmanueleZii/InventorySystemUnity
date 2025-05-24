using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class Food : Item
{
    public string nomeFood = "";
    public int fame = 20;
    Player player;
    void Start() {
      if (player == null)
           player = FindAnyObjectByType<Player>();   
    }
    public override void Use(Player player)
    {
        Debug.Log($"Hai Equippagiato{nomeFood} ti sfamato {fame}");
    }
}
