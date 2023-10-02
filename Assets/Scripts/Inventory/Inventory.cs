using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<ItemStack> Items;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public InventoryItemController[] InventoryItems;
    public DataManager DataManager;

    private void Awake()
    {
        Instance = this;
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }

    public void Add(ItemStack itemStack)
    {
        var existingItemStack = Items.Find(i => i.item.id == itemStack.item.id);

        if (existingItemStack != null)
        {
            existingItemStack.count += itemStack.count;
        }
        else
        {
            Items.Add(itemStack);
        }
    }

    public void Remove(ItemStack itemStack)
    {
        Items.Remove(itemStack);
        SetInventoryItems();
    }

    public void LoadInventory(SaveData.ItemData[] itemData)
    {
        Items.Clear();

        foreach (var data in itemData)
        {
            Item item = new Item();
            item.itemName = data.itemName;
            item.icon = data.icon;
            ItemStack itemStack = new ItemStack(item, data.count);
            Items.Add(itemStack);
        }
        Display();
    }

    public void Display()
    {
        ClearItems();

        foreach (var itemStack in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemCount = obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();

            if (itemStack.count > 1)
            {
                itemCount.text = itemStack.count.ToString();
            }

            itemName.text = itemStack.item.itemName;
            itemIcon.sprite = itemStack.item.icon;
        }

        SetInventoryItems();
    }

    private void ClearItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
    }

    private void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            if (InventoryItems[i] != null)
            {
                InventoryItems[i].Add(Items[i]);
            }
        }
    }

    private void SaveInventory()
    {
        DataManager.SaveGameData(Items);
    }
}

