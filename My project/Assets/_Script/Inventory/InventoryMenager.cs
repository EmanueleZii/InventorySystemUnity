using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryMenager : MonoBehaviour {
    public List<InventoryItem> inventoryItems;
    public List<InventorySlot> slots;
    public GameObject zaino;
    private bool isInventoryOpen = false;
    Item newItem;
    public GameObject inventoryItemPrefab;
    public Transform inventoryContent;

    //cerca sul inventario un oggetto che contiene itemData 
    public InventoryItem GetItemByType<T>() where T : Item {
        foreach (var item in inventoryItems) {
            if (item.itemData is T)
                return item;
        }
        return null;
    }
    // Questo metodo viene richiamato dal Button UI
    public void ToggleInventory() {
        isInventoryOpen = !isInventoryOpen;
        zaino.SetActive(isInventoryOpen);
    }
   public void AddItem(Item newItem) {
       // Cerca uno slot libero (assumendo tu abbia una lista di slot)
       var emptySlot = slots.Find(s => s.IsEmpty());
        if (emptySlot == null)
        {
            Debug.Log("Inventario pieno");
            return;
        }

        var newItemGO = Instantiate(inventoryItemPrefab, emptySlot.transform);
        var itemComponent = newItemGO.GetComponent<InventoryItem>();

        itemComponent.itemData = newItem;
        itemComponent.stackCount = 1;
        itemComponent.UpdateUI();

        emptySlot.SetItem(itemComponent);
        inventoryItems.Add(itemComponent);
    }
}
