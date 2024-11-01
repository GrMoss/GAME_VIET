using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab; // Prefab của item slot
    public Transform itemSlotContainer; // Container chứa các item slots
    public Sprite[] spritesItem; // Array of sprites for items

    private Dictionary<int, ItemSlotUI> activeItemSlots = new Dictionary<int, ItemSlotUI>();

    private void Start()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        // Xóa tất cả các slot cũ trước khi cập nhật lại
        foreach (var slot in activeItemSlots.Values)
        {
            Destroy(slot.gameObject);
        }
        activeItemSlots.Clear();

        // Lấy toàn bộ items từ Player
        List<Item_Data> inventoryItems = Player.Instance.GetAllItems();

        // Tạo một slot cho mỗi item và gán dữ liệu vào
        foreach (var item in inventoryItems)
        {
            if (!activeItemSlots.ContainsKey(item.IdItem))
            {
                // Tạo một slot mới cho item
                GameObject newSlotObj = Instantiate(itemSlotPrefab, itemSlotContainer);
                ItemSlotUI newSlot = newSlotObj.GetComponent<ItemSlotUI>();

                // Lấy sprite theo ID item
                Sprite itemSprite = spritesItem[item.IdItem];
                newSlot.SetItemData(item.IdItem, item.QuantityItem, itemSprite);

                // Thêm slot vào dictionary
                activeItemSlots[item.IdItem] = newSlot;
            }
            else
            {
                // Cập nhật số lượng nếu item đã tồn tại trong dictionary
                ItemSlotUI existingSlot = activeItemSlots[item.IdItem];
                int newQuantity = item.QuantityItem;
                existingSlot.SetItemData(item.IdItem, newQuantity, spritesItem[item.IdItem]);
            }
        }
    }
}