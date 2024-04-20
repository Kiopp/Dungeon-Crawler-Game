using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        RefreshInventoryUI();
    }

    public void Remove(Item item)
    {
        int index = Items.IndexOf(item);
        if (index != -1)
        {
            Items.RemoveAt(index);
            Destroy(ItemContent.GetChild(index).gameObject); // Destroy the UI element
            RefreshInventoryUI();
        }
    }

    public void RefreshInventoryUI()
    {
        // Clear existing UI items
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }   

        // Re-create UI items from the Items list
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.GetName;
            itemIcon.sprite = item.GetIcon;

            // Set the item on the controller
            InventoryItemController controller = obj.GetComponent<InventoryItemController>();
            controller.Item = item; // Set directly

            // Setup the button to remove the item
            removeButton.onClick.AddListener(() => Remove(item));
        }
    }
}