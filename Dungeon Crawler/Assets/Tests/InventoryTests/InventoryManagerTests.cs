using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class InventoryManagerTests
{
    private InventoryManager inventoryManager;
    private GameObject inventoryGameObject;

    [SetUp]
    public void SetUp()
    {
        inventoryGameObject = new GameObject();
        inventoryManager = inventoryGameObject.AddComponent<InventoryManager>();

        // Create the necessary UI environment
        var canvasGameObject = new GameObject("Canvas");
        var canvas = canvasGameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        var canvasScaler = canvasGameObject.AddComponent<CanvasScaler>();
        var graphicRaycaster = canvasGameObject.AddComponent<GraphicRaycaster>();

        // Set up ItemContent
        var itemContentGameObject = new GameObject("ItemContent");
        itemContentGameObject.transform.SetParent(canvas.transform);
        inventoryManager.GetType().GetField("ItemContent", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.SetValue(inventoryManager, itemContentGameObject.transform);

        // Set up InventoryItem prefab with necessary child items for UI
        var inventoryItemPrefab = new GameObject("InventoryItem");
        inventoryItemPrefab.transform.SetParent(canvas.transform);

        var itemNameGO = new GameObject("ItemName");
        itemNameGO.transform.SetParent(inventoryItemPrefab.transform);
        itemNameGO.AddComponent<Text>();

        var itemIconGO = new GameObject("ItemIcon");
        itemIconGO.transform.SetParent(inventoryItemPrefab.transform);
        itemIconGO.AddComponent<Image>();

        var removeButtonGO = new GameObject("RemoveButton");
        removeButtonGO.transform.SetParent(inventoryItemPrefab.transform);
        removeButtonGO.AddComponent<Button>();

        inventoryManager.GetType().GetField("InventoryItem", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.SetValue(inventoryManager, inventoryItemPrefab);
    }



    [TearDown]
    public void TearDown()
    {
        // Clean up after tests
        Object.DestroyImmediate(inventoryGameObject);
    }

    private Item CreateTestItem(string name, Sprite icon = null) // Defaulting icon to null if not provided
    {
        var item = ScriptableObject.CreateInstance<Item>();
        item.GetName = name;
        item.GetIcon = icon; // Can pass null or a specific Sprite as needed
        return item;
    }


    [Test]
    public void TestAddItem()
    {
        var item = CreateTestItem("Test Item", null);
        inventoryManager.Add(item);
        Assert.IsTrue(inventoryManager.Contains(item), "Item should be added to the inventory");
    }

    [Test]
    public void TestRemoveItem()    
    {
        var item = CreateTestItem("Test Item", null);
        inventoryManager.Add(item); // Directly add to the list for setup
        inventoryManager.Remove(item);
        Assert.IsFalse(inventoryManager.Contains(item), "Item should be removed from the inventory");
    }
}
