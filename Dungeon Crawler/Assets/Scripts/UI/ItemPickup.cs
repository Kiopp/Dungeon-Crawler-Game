using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);

        InventoryManager.Instance.ListItems();
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}