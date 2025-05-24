using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Player player; // da assegnare via Inspector
    public int damage = 10;

    public HealthPotion healthPotion;
    public InventoryItem inventoryItem;

    void Start()
    {
        if (player == null)
        player = FindAnyObjectByType<Player>();

    if (healthPotion == null)
        healthPotion = FindAnyObjectByType<HealthPotion>();

    if (inventoryItem == null)
        inventoryItem = FindAnyObjectByType<InventoryItem>();
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
    public void prendiPozione()
    {
         if (player == null) {
        Debug.LogWarning("Player non assegnato!");
        return;
    }

    if (inventoryItem == null) {
        Debug.LogWarning("InventoryItem non assegnato!");
        return;
    }

       inventoryItem.IncreaseStack(1);
    }
}
