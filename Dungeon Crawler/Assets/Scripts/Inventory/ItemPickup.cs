using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private Item item;

    private void Start()
    {
        item = GetComponentInParent<ItemDrop>().GetItem(); // Get item from parent ItemDrop
    }

    void Pickup()
    {
        if (item == null)
        {
            Debug.LogError("Attempted to pick up a null item.");
            return;
        }

        Debug.Log($"Picking up item: {item.GetName}");
        InventoryManager.Instance.Add(item);
        Destroy(transform.parent.parent.gameObject); // Destroy the entire enemy object
    }

    private void OnMouseDown()
    {
        Pickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        Pickup();
    }
}