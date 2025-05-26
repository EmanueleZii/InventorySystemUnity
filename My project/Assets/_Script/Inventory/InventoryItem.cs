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

    void Start() {

        // verifiche se itemData e di tipo corretto
        if (itemData is HealthPotion)
            healthPotion = (HealthPotion)itemData;
        if (itemData is Food)
            food1 = (Food)itemData;
        //Controllo dei vari oggetti e instanze se sono null...
        if (player == null)
            player = FindAnyObjectByType<Player>();
        if (canvas == null) {
            canvas = GetComponentInParent<Canvas>();
            canvas = FindObjectOfType<Canvas>();
        }
        if (canvas == null) {
            enabled = false;
            return;
        }
        // canvas group component se è null e non ce lo va ad aggiungere....
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    } 
   // Aggiorna la UI
    public void UpdateUI() {
        // verifica se  l item e superiore a un 1 contenuto nello slot se e zero non stampa nulla
         if (stackText == null)
        {
            Debug.LogWarning("stackText non è assegnato!");
            return;
        }
        // stampa il numero dei item a pato che il count e superiore a 1
       stackText.text = stackCount > 1 ? stackCount.ToString() : "";
    }

    // incrementa a quantita di un item
    public void IncreaseStack(int amount){

        if (itemData is Food food || itemData is HealthPotion potion)
        {
            stackCount = Mathf.Min(stackCount + amount, maxStack);
            UpdateUI();
        }
    }

    public void DecreaseStack(int amount, PointerEventData eventData) {
        // decrementa a quantita di un item 
        stackCount -= amount;
        if (stackCount <= 0) {
            if (itemData is HealthPotion || itemData is Food) {
                Destroy(gameObject); // Rimuove l'oggetto dalla scena
            }
        }
        else {
            UpdateUI();
        }
    }

    //mette sopra nella gerarchia l item che si sta trascinando con il mouse...
    public void OnBeginDrag(PointerEventData eventData) {
         originalSlot = transform.parent;
        transform.SetParent(canvas.transform); // porta sopra il canvas per evitare problemi di raycast
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        
        canvasGroup.blocksRaycasts = true;
        
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
        // per fare in modo che i consumabili si usano con il tasto destro del mouse...
        if (eventData.button == PointerEventData.InputButton.Right) {
            if (itemData != null) {
                // verifica se l itemdata e di tipo healthpotion o food che sono gli unici due consumabili...
                if (itemData is HealthPotion || itemData is Food){
                    //li usa  e poi decrementa di uno lo stack di item che si ha ne l inventario....
                    itemData.Use(player);
                    DecreaseStack(1, eventData);
                }
            }
        }
    }
   
}