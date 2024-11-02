using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Data 
{
    public int IdItem; 
    public int QuantityItem;

    public Item_Data(int idItem, int quantityItem)
    {
        IdItem = idItem;
        QuantityItem = quantityItem;
    }
}