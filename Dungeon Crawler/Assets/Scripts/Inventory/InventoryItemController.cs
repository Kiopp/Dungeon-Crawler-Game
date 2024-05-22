using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    // Written by Jesper Wentzell
    public Item item { get; protected set; }
    public InventoryManager manager { get; protected set; }
    private Player player { get; set; }

    public void SetUpItem(InventoryManager manager, Item item)
    {
        player = FindObjectOfType<Player>();
        this.manager = manager;
        this.item = item;
    }

    public void UseItem()
    {
        Debug.Log($"Using {item.GetName}");
        if (item == null)
        {
            return;
        }

        if (item is Weapon weapon)
        {
            player.EquipWeapon(weapon);
        }
        else if (item is Consumable consumable)
        {
            consumable.UseItem(player);
            manager.Remove(consumable);

        }
    }
}
