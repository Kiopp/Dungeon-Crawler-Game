using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new();

    public void AddItem(ItemData itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(ItemData itemToRemove)
    {
        items.Remove(itemToRemove);
    }
}
