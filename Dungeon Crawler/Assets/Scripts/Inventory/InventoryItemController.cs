using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private Item item;

    public Item Item 
    {
        get { return item; }
        set { item = value; } // Setter allows the item to be updated if necessary
    }

    public void RemoveItem()
    {
        if (item == null)
        {
            Debug.LogError("Attempted to remove a null item.");
            return;
        }

        Debug.Log($"Removing item: {item.GetName}");
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
}
