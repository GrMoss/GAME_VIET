using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab; // Prefab của item slot
    public Transform itemSlotContainer; // Container chứa các item slots

    private Dictionary<int, ItemSlotUI> activeItemSlots = new Dictionary<int, ItemSlotUI>();

    public GameObject[] baoVatSprite;
    public GameObject[] spriteOJSAT; 
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
            // Tạo một slot mới cho item
            GameObject newSlotObj = Instantiate(itemSlotPrefab, itemSlotContainer);
            ItemSlotUI newSlot = newSlotObj.GetComponent<ItemSlotUI>();

            // Gán dữ liệu cho slot
            newSlot.SetItemData(item.IdItem, item.QuantityItem);

            // Thêm slot vào dictionary
            activeItemSlots[item.IdItem] = newSlot;
        }

        // Cập nhật trạng thái của baoVatSprite
        if (baoVatSprite.Length > 3 && baoVatSprite[3] != null)
        {
            baoVatSprite[3].SetActive(false); // Tắt baoVatSprite[10] ban đầu
            spriteOJSAT[3].SetActive(true);
        }
        if (baoVatSprite.Length > 5 && baoVatSprite[5] != null)
        {
            baoVatSprite[5].SetActive(false); // Tắt baoVatSprite[11] ban đầu
            spriteOJSAT[5].SetActive(true);
        }

        // Kiểm tra các item đặc biệt (IdItem 10 và 11)
        foreach (var item in inventoryItems)
        {
            if (item.IdItem == 13 && item.QuantityItem >= 1 && baoVatSprite.Length > 3)
            {
                baoVatSprite[3].SetActive(true);
                spriteOJSAT[3].SetActive(false);
            }
            if (item.IdItem == 15 && item.QuantityItem >= 1 && baoVatSprite.Length > 5)
            {
                baoVatSprite[5].SetActive(true);
                spriteOJSAT[5].SetActive(false);
            }
        }
    }
}