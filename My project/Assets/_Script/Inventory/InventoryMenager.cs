using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryMenager : MonoBehaviour {
    public List<InventoryItem> inventoryItems;
    public GameObject zaino;
    private bool isInventoryOpen = false;
    Item newItem;
    public GameObject inventoryItemPrefab;
    public Transform inventoryContent;

    //cerca sul inventario un oggetto che contiene itemData 
     public InventoryItem GetItemByType<T>() where T : Item
    {
        foreach (var item in inventoryItems)
        {
            if (item.itemData is T)
                return item;
        }

        return null; // Nessun item trovato
    }
    
    // Questo metodo viene richiamato dal Button UI
    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        zaino.SetActive(isInventoryOpen);
    }
   public void AddItem(Item newItem)
    {
        // Cerca un item 
        var existingItem = inventoryItems.Find(i => i.itemData == newItem);

        if (existingItem != null){
            existingItem.IncreaseStack(1);
            return;
        }
        
        // Crea un item 
        var newItemGO = Instantiate(inventoryItemPrefab, inventoryContent);
        var itemComponent = newItemGO.GetComponent<InventoryItem>();
        itemComponent.itemData = newItem;
        itemComponent.stackCount = 1;

        // Setta icona, se ce
        var img = newItemGO.GetComponent<Image>();
        if (img != null && newItem.icon != null)
            img.sprite = newItem.icon;

        inventoryItems.Add(itemComponent);

        Debug.Log("Aggiunto: " + newItem.itemName);
    }
}
