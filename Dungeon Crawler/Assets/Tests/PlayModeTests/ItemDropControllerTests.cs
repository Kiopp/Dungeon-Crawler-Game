using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TestFixture]
public class ItemDropControllerTests
{
    /* Written by Jesper Wentzell */
    private ItemDropController controller;
    private List<ItemDrop> lootTable;

    [SetUp]
    public void Setup()
    {
        // Create a mock ItemDropController and assign it a loot table.
        controller = new GameObject().AddComponent<ItemDropController>();
        lootTable = new List<ItemDrop>();
        controller.SetLootTable(lootTable);
    }

    // Tests the DropItem method with only one item in loot table. With only one item in the loot table it should always drop.
    [Test]
    public void DropItem_SingleItem_DropsItem()
    {
        // Add one item to loot table
        MockItemDrop mockItem = new GameObject().AddComponent<MockItemDrop>();
        lootTable.Add(mockItem);

        // Drop item
        controller.DropItem();

        // Assert that the item was dropped
        Assert.IsTrue(mockItem.IsDropped);
    }

    // Tests the DropItem method with multiple items in loot table. Assure that only one item from the table is dropped.
    [Test]
    public void DropItem_MultipleItems_DropOneItem()
    {
        // Add items to loot table
        MockItemDrop mockItem1 = new GameObject().AddComponent<MockItemDrop>();
        MockItemDrop mockItem2 = new GameObject().AddComponent<MockItemDrop>();
        lootTable.Add(mockItem1);
        lootTable.Add(mockItem2);

        // Drop item
        controller.DropItem();

        // Check if only one item dropped using xor opperator
        Assert.IsTrue(mockItem1.IsDropped ^ mockItem2.IsDropped);
    }

    // Mock class for ItemDrop
    public class MockItemDrop : ItemDrop
    {
        public bool IsDropped { get; private set; }

        public void Start()
        {
            IsDropped = false;
            this.dropChance = 1f;
        }

        public override void Drop()
        {
            IsDropped = true;
        }
    }
}
