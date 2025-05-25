using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Transform originalSlot; // per salvare lo slot originale del item
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public Item itemData; // Riferimento al ScriptableObject

    HealthPotion healthPotion;
    Food food1;
    public int maxStack = 60; // il massimo numero stock di item raccoglibili 
    public int stackCount = 60; // lo stock attuale che si ha nel inventario

    // UI
    public Text stackText; //il testo dei stack dei vari items...

    Player player; //instanza del player
   


    void Start()
    {
        if (itemData is HealthPotion)
            healthPotion = (HealthPotion)itemData;
        if (itemData is Food)
            food1 = (Food)itemData;
        //Controllo dei vari oggetti e instanze se sono null...
        if (player == null)
            player = FindAnyObjectByType<Player>();

        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
            canvas = FindObjectOfType<Canvas>();
        }

        if (canvas == null)
        {
            enabled = false;
            return;
        }
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void UpdateUI() // Aggiorna la UI
    {
        // verifica se  l item e superiore a un 1 contenuto nello slot se e zero non stampa nulla
        if (stackCount > 1)
            stackText.text = stackCount.ToString();
        else
            stackText.text = "";
    }

    public void IncreaseStack(int amount) // incrementa a quantita di un item
    {
        if (itemData is HealthPotion potion)
        {
            stackCount = Mathf.Min(stackCount + amount, maxStack);
            UpdateUI();
        }
        else if (itemData is Food food)
        {
            stackCount = Mathf.Min(stackCount + amount, maxStack);
            UpdateUI();
        }
        else
        {
            Debug.LogWarning("Item non ha maxStack definito!");
        }
    }

    public void DecreaseStack(int amount, PointerEventData eventData)
    {
        // decrementa a quantita di un item 
        stackCount -= amount;
        if (stackCount <= 0)
        {
            if (itemData is HealthPotion || itemData is Food)
            {
                Destroy(gameObject); // Rimuove l'oggetto dalla scena
            }
        }
        else
        {
            UpdateUI();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalSlot = transform.parent;
        transform.SetParent(canvas.transform); // Per stare sopra gli altri
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        
        canvasGroup.blocksRaycasts = true;

        // Se lo slot non è uno slot, ritorna allo slot di prima...
        /* if (transform.parent == canvas.transform || transform.parent.GetComponent<InventorySlot>() == null)
         {
             transform.SetParent(originalSlot);
             transform.localPosition = Vector3.zero;
         }
         else
         {
             // Posiziona bene l'item nel nuovo slot
             transform.localPosition = Vector3.zero;
         }*/

        //non funzionava...
        //bool isValidParent = transform.parent != canvas.transform && transform.parent.GetComponent<InventorySlot>() ||transform.parent.GetComponent<InventorySlotEquip>() != null;
        var parent = transform.parent;
        //Questo si...
        bool isValidParent = parent != canvas.transform &&
                    (parent.GetComponent<InventorySlot>() != null ||
                     parent.GetComponent<InventorySlotEquip>() != null);

        if (!isValidParent) {
            // Oggetto rilasciato fuori dall'inventario
            transform.SetParent(originalSlot);
            transform.localPosition = Vector3.zero;
        }
        else {
            // Posiziona bene l'item nel nuovo slot
            transform.localPosition = Vector3.zero;
        }

    }
    //Per rilevare il click sul item...
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            if (itemData != null) {
                if (itemData is HealthPotion || itemData is Food) {
                    itemData.Use(player);
                    DecreaseStack(1, eventData);
                }
            }
        }
    }
   
}