using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ItemTests
{
    private Item testItem;

    [SetUp]
    public void SetUp()
    {
        testItem = ScriptableObject.CreateInstance<Item>();
    }

    [Test]
    public void RarityModifier_ReturnsCorrectModifier()
    {
        // Arrange
        var rarityField = typeof(Item).GetField("Rarity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var itemRarityEnum = typeof(Item).GetNestedType("ItemRarity", System.Reflection.BindingFlags.NonPublic);
        var rarityValue = System.Enum.Parse(itemRarityEnum, "Epic");
        rarityField.SetValue(testItem, rarityValue);

        var expectedModifier = 1.5;

        // Act
        var actualModifier = testItem.RarityModifier();

        // Assert
        Assert.AreEqual(expectedModifier, actualModifier);
    }
}