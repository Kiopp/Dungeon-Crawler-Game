using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public Button RemoveButton;

    public void RemoveItem()
    {
        if (item == null)
        {
            Debug.LogError("Attempted to remove a null item.");
            return;
        }

        Debug.Log($"Removing item: {item.itemName}");
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
}
