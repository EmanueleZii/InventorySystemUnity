using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Transform originalParent;
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public Item itemData; // Riferimento al ScriptableObject

    public int maxStack = 60;
    public int stackCount = 60;
    
    // UI
    public Text stackText;

    void Start()
    {
        

        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
            canvas = FindObjectOfType<Canvas>();
        }

        if (canvas == null)
        {
            Debug.LogError("No Canvas found in the scene. InventoryItem requires a Canvas to function.");
            enabled = false;
            return;
        }
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    void UpdateUI()
    {
        stackText.text = stackCount > 1 ? stackCount.ToString() : "";
    }

    public void IncreaseStack(int amount)
    {
        stackCount = Mathf.Min(stackCount + amount, maxStack);
        UpdateUI();
    }

    public void DecreaseStack(int amount)
    {
        stackCount -= amount;
        if (stackCount <= 0)
        {
            Destroy(gameObject); // Rimuove l'oggetto dalla scena
        }
        else
        {
            UpdateUI();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform); // Per stare sopra gli altri
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Se il parent NON è uno slot valido, ritorna al parent originale
        if (transform.parent == canvas.transform || transform.parent.GetComponent<InventorySlot>() == null)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
        else
        {
            // Posiziona bene l'item nel nuovo slot
            transform.localPosition = Vector3.zero;
        }
    }
    //Per rilevare il click del item...
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) {
            Debug.Log("Click sull'item: " + (itemData != null ? itemData.name : "NULL"));
            if (itemData != null)
                itemData.Use();
            else
                Debug.LogWarning("itemData è NULL");
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (itemData != null)
            {
                itemData.Use();
                DecreaseStack(1);
            }
        }
    }
}