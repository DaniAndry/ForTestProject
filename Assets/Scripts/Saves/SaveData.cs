using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int bullets;
    public ItemData[] items;

    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public int count;
        public Sprite icon;
    }
}