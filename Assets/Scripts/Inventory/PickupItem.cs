using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemStack Item;

    public void Pickup()
    {
        Inventory.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Pickup();
        }
    }
}
