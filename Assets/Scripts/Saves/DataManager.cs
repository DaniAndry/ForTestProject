using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public Inventory inventory;
    private string _savePath;

    private void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "save.json");
        LoadGameData();
    }

    public void SaveGameData(List<ItemStack> items)
    {
        SaveData data = new SaveData();
        data.items = new SaveData.ItemData[items.Count];

        for (int i = 0; i < items.Count; i++)
        {
            data.items[i] = new SaveData.ItemData
            {
                itemName = items[i].item.itemName,
                count = items[i].count,
                icon = items[i].item.icon
            };
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_savePath, json);
    }

    public void LoadGameData()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            inventory.LoadInventory(data.items);
        }
        else
        {
            Debug.LogError("Save file not found!");
        }
    }
}
