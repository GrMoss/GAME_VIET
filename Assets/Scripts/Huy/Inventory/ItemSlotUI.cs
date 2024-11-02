using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemSlotUI : MonoBehaviour
{
    public TextMeshProUGUI itemQuantityText;
    private int itemIdItem;
    public Image imageItem;

    public Sprite[] imagesItem; // Array of sprites for items

    // Phương thức để gán dữ liệu item vào UI slot
    public void SetItemData(int itemId, int quantity)
    {
        itemIdItem = itemId;
        itemQuantityText.text = quantity.ToString();

        // Kiểm tra xem itemId có hợp lệ không trước khi gán sprite
        if (itemId >= 0 && itemId < imagesItem.Length)
        {
            imageItem.sprite = imagesItem[itemId];
        }
        else
        {
            Debug.LogWarning("Invalid itemId: " + itemId);
        }
    }
}