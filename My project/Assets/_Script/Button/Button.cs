using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Player player; // da assegnare via Inspector
    public int damage = 10;

    public HealthPotion healthPotion;
    public InventoryItem inventoryItem;
    public InventoryMenager inventoryManager;
    public Item itemToAdd;

    void Start()
    {
        if (player == null)
            player = FindAnyObjectByType<Player>();

        if (healthPotion == null)
            healthPotion = FindAnyObjectByType<HealthPotion>();

        if (inventoryItem == null)
            inventoryItem = FindObjectOfType<InventoryItem>();

    }

    public void OnAddItemButtonClicked()
    {
        if (inventoryManager != null && itemToAdd != null)
            inventoryManager.AddItem(itemToAdd);
        else
            Debug.LogWarning("InventoryManager o ItemToAdd non assegnato.");
    }

    public void prendiDanno()
    {
        if (player != null)
        {
            player.health -= damage;
            Debug.Log("Danno inflitto: " + damage);
        }
        else
        {
            Debug.LogWarning("Player non assegnato!");
        }
    }
    public void prendiPozione() {
        
       if (player == null) {
            Debug.LogWarning("Player non assegnato!");
            return;
        }

        InventoryItem[] items = FindObjectsOfType<InventoryItem>();
        InventoryItem potionItem = null;

        foreach(var item in items) {
            if (item.itemData is HealthPotion) {
                potionItem = item;
                break;
            }
        }

        if (potionItem != null)
        {
            Debug.Log($"Aumento stack per pozione: {potionItem.itemData.name}");
            potionItem.IncreaseStack(1);
        }
        else {
            Debug.LogWarning("Nessuna HealthPotion trovata nell'inventario!");
        }
    }
}
