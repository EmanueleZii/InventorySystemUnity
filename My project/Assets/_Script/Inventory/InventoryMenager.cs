using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
   public List<InventoryItem> inventoryItems;

    public InventoryItem GetItemByType<T>() where T : Item
    {
        return inventoryItems.Find(i => i.itemData is T);
    }
}
