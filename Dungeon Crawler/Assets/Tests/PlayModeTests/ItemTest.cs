using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ItemTests
{

    [Test]
    public void RarityModifier_ReturnsCorrectModifier()
    {
        // Arrange
        var item = ScriptableObject.CreateInstance<Item>();

        // Private field access through reflection
        var rarityField = typeof(Item).GetField("Rarity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var itemRarityEnum = typeof(Item).GetNestedType("ItemRarity", System.Reflection.BindingFlags.NonPublic);
        var rarityValue = System.Enum.Parse(itemRarityEnum, "Epic"); 
        rarityField.SetValue(item, rarityValue);

        var expectedModifier = 1.5;

        // Act
        var actualModifier = item.RarityModifier();

        // Assert
        Assert.AreEqual(expectedModifier, actualModifier);
    }
}