using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Create New Weapon")]
public class Weapon : Item
{
    [SerializeField] private double dmg; //Base damage of the weapon 

    //Calculates the damage of a single hit from the weapon
    public double dmgDealt()
    {
        return dmg * RarityModifier();
    }
}