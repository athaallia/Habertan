using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public InventorySlot[] inventorySlotsHUD;
    public GameObject inventoryItemPrefab;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public bool AddItem(Item item)
    {
        // Find any empty slot
        for (int i = 0; i < inventorySlotsHUD.Length; i++)
        {
            InventorySlot slot = inventorySlotsHUD[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }



    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);

        InventoryItem newItem = newItemGo.GetComponent<InventoryItem>();

        newItem.InitialiseItem(item);
    }

}
