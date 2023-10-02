using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public ItemStack _item;

    public void Add(ItemStack item)
    {
        _item = item;
    }

    public void Remove()
    {
        Inventory.Instance.Remove(_item);
        Destroy(gameObject);
    }
}
