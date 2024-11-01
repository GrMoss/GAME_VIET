using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Id;
    public string PlayerName;
    public int Gender;
    public int[] IdBV;
    public float[] PositionPlayer;
    public List<Item_Data> Inventory;
    public DateTime SaveTime;
    public Dictionary<int, bool> CompletedLevels;
    public PlayerData(Player player)
    {
        Id = player.id;
        PlayerName = player.playerName;
        Gender = player.gender;
        IdBV = player.idBVArray;
        PositionPlayer = new float[3]
        {
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z
        };
        Inventory = new List<Item_Data>(player.inventory);
        SaveTime = DateTime.Now;
        CompletedLevels = new Dictionary<int, bool>(player.completedLevels);
    }
}