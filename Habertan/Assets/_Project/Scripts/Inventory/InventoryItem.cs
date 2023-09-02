using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image imageComponent;



    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;



    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }



    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        imageComponent.sprite = newItem.image;
    }



    // Drag and Drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        imageComponent.raycastTarget = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        imageComponent.raycastTarget = true;
    }
}
