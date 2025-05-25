using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
    public List<InventoryItem> inventoryItems;
    public GameObject zaino;
    private bool isInventoryOpen = false;
    Item newItem;
    public GameObject inventoryItemPrefab;
    public Transform inventoryContent;
    public InventoryItem GetItemByType<T>() where T : Item
    {
        return inventoryItems.Find(i => i.itemData is T);
    }

    // Questo metodo viene richiamato dal Button UI
    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        zaino.SetActive(isInventoryOpen);
    }
   public void AddItem(Item newItem)
    {
        // Cerca item esistente
        var existingItem = inventoryItems.Find(i => i.itemData == newItem);

        if (existingItem != null)
        {
            existingItem.IncreaseStack(1);
            return;
        }

        // Crea nuovo item UI
        var newItemGO = Instantiate(inventoryItemPrefab, inventoryContent);
        var itemComponent = newItemGO.GetComponent<InventoryItem>();
        itemComponent.itemData = newItem;
        itemComponent.stackCount = 1;

        // Setta icona, se presente
        var img = newItemGO.GetComponent<UnityEngine.UI.Image>();
        if (img != null && newItem.icon != null)
            img.sprite = newItem.icon;

        inventoryItems.Add(itemComponent);

        Debug.Log("Aggiunto: " + newItem.itemName);
    }
}
