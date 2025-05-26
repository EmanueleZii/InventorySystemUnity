using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InventorySlotEquip : MonoBehaviour, IDropHandler {
    public bool IsOccupied => transform.childCount > 0;
    // Dove Item è la classe base
    public Item itemData;
    Player player;
    void Start() {
        if (player == null)
            player = FindAnyObjectByType<Player>();
    }
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag == null) return;
        if (IsOccupied) return;

        var itemUI = eventData.pointerDrag.GetComponent<ItemUI>();
        if (itemUI == null) return;

        if (itemUI.itemData is Armor armor || itemUI.itemData is Weapon weapon) {
            itemData = itemUI.itemData;
            itemData.Use(player);

            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }
    }
    
}
