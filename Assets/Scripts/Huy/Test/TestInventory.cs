using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public void UpdateTest()
    {
        Player.Instance.AddOrUpdateItemById(6,5);
        Player.Instance.AddOrUpdateItemById(4,3);
        Player.Instance.AddOrUpdateItemById(5,1);
        inventoryUI.UpdateInventory();
    }
}
