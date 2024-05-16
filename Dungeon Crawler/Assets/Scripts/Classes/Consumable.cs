using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{

    [SerializeField] private double healing; //Base healing amount

    // Calculates the amout of health that is regained when the consumable is used
    public double healingAmount()
    {
        return healing * RarityModifier();
    }

}