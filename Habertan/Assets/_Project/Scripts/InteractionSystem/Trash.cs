using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    [SerializeField] private Item item;
    [SerializeField] private string _prompt;



    public string InteractionPrompt => _prompt;



    public bool Interact(Interactor interactor)
    {
        Debug.Log("Pick Up Item!");
        if (InventoryManager.Instance.AddItem(item))
        {
            ItemSpawner.Instance.ReduceCounter();
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
