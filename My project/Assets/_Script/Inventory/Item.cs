using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe astratta Item..

public abstract class Item : ScriptableObject
{
     public string id;
    public string itemName;
    public Sprite icon;
    public abstract void Use(Player player);
}