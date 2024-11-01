using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Data 
{
    internal Sprite ItemImage;

    public int IdItem {get; set;}
    public int QuantityItem {get; set;}

        public Item_Data(int idItem, int quantityItem)
    {
        IdItem = idItem;
        QuantityItem = quantityItem;
    }
}
