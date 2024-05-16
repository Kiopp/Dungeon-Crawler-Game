using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private Item item; 

    void Pickup()
    {
        if (item == null)
        {
            Debug.LogError("Attempted to pick up a null item.");
            return;
        }

        Debug.Log($"Picking up item: {item.GetName}");
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
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