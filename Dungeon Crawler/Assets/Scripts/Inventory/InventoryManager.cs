using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField]
    private List<Item> items = new List<Item>();

    [SerializeField]
    private Transform itemContent;

    [SerializeField]
    private GameObject inventoryItem;

    public List<Item> Items => items;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
        RefreshInventoryUI();
    }

    public void Remove(Item item)
    {
        int index = items.IndexOf(item);
        if (index != -1)
        {
            items.RemoveAt(index);
            if (Application.isEditor)
            {
                DestroyImmediate(itemContent.GetChild(index).gameObject); // Use DestroyImmediate for editor tests
            }
            else
            {
                Destroy(itemContent.GetChild(index).gameObject);
            }
            RefreshInventoryUI();
        }
    }

    public void RefreshInventoryUI()
    {
        // Clear existing UI items
        foreach (Transform child in itemContent)
        {
            Destroy(child.gameObject);
        }   

        // Re-create UI items from the Items list
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.GetName;
            itemIcon.sprite = item.GetIcon;

            // Setup the button to remove the item
            removeButton.onClick.AddListener(() => Remove(item));
        }
    }
}   