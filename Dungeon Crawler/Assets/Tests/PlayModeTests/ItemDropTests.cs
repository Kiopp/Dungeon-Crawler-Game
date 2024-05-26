using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ItemDropTests
{
    private GameObject testObject;
    private ItemDrop dropItem;

    [SetUp]
    public void Setup()
    {
        testObject = new GameObject();
        dropItem = testObject.AddComponent<ItemDrop>();
    }

    [Test]
    public void Drop_EnabledParentObject()
    {
        // Simulate item dropping
        dropItem.Drop();

        // Check if object is set active correctly
        Assert.IsTrue(testObject.activeSelf);
    }
}
