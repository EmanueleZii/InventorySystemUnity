using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class InventorySlot :  MonoBehaviour, IDropHandler
{
    
    public bool IsOccupied => transform.childCount > 0;
    public InventoryItem currentItem;  // riferimento all'item nello slot

    public bool IsEmpty()
    { 
       return currentItem == null;
    }

    public void SetItem(InventoryItem item)
    {
        currentItem = item;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
    }
    public void ClearSlot()
    {
        currentItem = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
            {
                // Opzionale: rifiuta se slot occupato
                if (IsOccupied) return;

                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.transform.localPosition = Vector3.zero; // Centra l'item nello slot
            }
    }
}
