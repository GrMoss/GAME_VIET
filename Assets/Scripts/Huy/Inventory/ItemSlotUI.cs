using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemSlotUI : MonoBehaviour
{
    public TextMeshProUGUI itemQuantityText;
    public Image itemImage;
    private int itemIdItem;

    // Phương thức để gán dữ liệu item vào UI slot
    public void SetItemData(int itemId, int quantity, Sprite image)
    {
        itemIdItem = itemId;
        itemQuantityText.text = quantity.ToString();
        itemImage.sprite = image;
    }
}
