using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Item/Create New Consumable")]
public class Consumable : Item
{

    [SerializeField] private double healing; //Base healing amount

    // Calculates the amout of health that is regained when the consumable is used
    public double healingAmount()
    {
        return healing * RarityModifier();
    }

    // Use an item on an entity
    public void UseItem(Entity target)
    {
        target.Heal(healingAmount());
    }

}