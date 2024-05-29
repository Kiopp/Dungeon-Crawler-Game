using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class WeaponTests
{
    private Weapon _weapon;

    [SetUp]
    public void SetUp()
    {
        _weapon = ScriptableObject.CreateInstance<Weapon>();
    }

    [Test]
    public void dmgDealt_ReturnsCorrectDamage()
    {
        // Arrange
        double baseDamage = 50.0;
        typeof(Weapon).GetField("dmg", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(_weapon, baseDamage);

        var rarityField = typeof(Item).GetField("Rarity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var itemRarityEnum = typeof(Item).GetNestedType("ItemRarity", System.Reflection.BindingFlags.NonPublic);
        var rarityValue = System.Enum.Parse(itemRarityEnum, "Epic");
        rarityField.SetValue(_weapon, rarityValue);

        double expectedModifier = 1.5; // Epic rarity
        double expectedDamage = baseDamage * expectedModifier;

        // Act
        double actualDamage = _weapon.dmgDealt();

        // Assert
        Assert.AreEqual(expectedDamage, actualDamage);
    }
}
