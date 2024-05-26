using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{
    /* Written by Jesper Wentzell */
    [SerializeField] private List<ItemDrop> lootTable;

    public void DropItem()
    {
        // Calculate total probability to drop an item (should be 1f, but could be different, however then the probability isn't in percent)
        float totalProbability = 0f;
        foreach (var itemDrop in lootTable)
        {
            totalProbability += itemDrop.GetDropChance();
        }

        // Random roll and probability check
        float randomRoll = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;

        foreach (var itemDrop in lootTable)
        {
            cumulativeProbability += itemDrop.GetDropChance();

            if (randomRoll <= cumulativeProbability)
            {
                // Drop item
                itemDrop.Drop();
                break;
            }
        }
    }

    // Used for testing
    public void SetLootTable(List<ItemDrop> table)
    {
        lootTable = table;
    }
}
