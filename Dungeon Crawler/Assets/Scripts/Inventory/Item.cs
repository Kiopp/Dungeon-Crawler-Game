using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private int id; // Item ID
    [SerializeField] private string itemName; // Name of the item
    [SerializeField] private int Value; // Monetary value of the item
    [SerializeField] private Sprite icon;
    [SerializeField] private string description;

    [SerializeField]
    private enum ItemRarity // Different item rarities and their corresponding modifier values
    {
        Common = 100,
        Uncommon = 125,
        Rare = 150,
        Epic = 175,
        Legendary = 200
    }

    [SerializeField] private ItemRarity Rarity; // Rarity of the item 

    public string GetName
    {
        get { return itemName; }
    }

    public Sprite GetIcon
    {
        get { return icon; }
    }

    // Calculates the rarity modifier
    public double RarityModifier()
    {
        double Modifier = (int)Rarity / 100.0;
        return Modifier;
    }
}