using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;
using System;


public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private int Id;
    private int Gender;
    private string PlayerName;
    private int[] IdBV;
    private float[] PositionPlayer = new float[3]; // Khởi tạo mảng cho PositionPlayer
    private List<Item_Data> Inventory = new List<Item_Data>();  // Danh sách Item_Data

    private Dictionary<int, bool> CompletedLevels = new Dictionary<int, bool>();

    private DateTime SaveTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Kiểm tra và khởi tạo vị trí nếu chưa được thiết lập
        if (PositionPlayer == null || PositionPlayer.Length < 3)
        {
            PositionPlayer = new float[3] { -6.1f, -0.9f, 0f };
        }   
    }

    public int id
    {
        get { return Id; }
        set { Id = value; } 
    }
    public string playerName
    {
        get { return PlayerName; }
        set { PlayerName = value; } 
    }

    public int gender
    {
        get { return Gender; }
        set { Gender = value; }
    }

    public int[] idBVArray
    {
        get { return IdBV; }
        set { IdBV = value; }
    }

    public float[] positionPlayer
    {
        get { return PositionPlayer; }
        set { PositionPlayer = value; }
    }

    public List<Item_Data> inventory
    {
        get { return Inventory; }
        set { Inventory = value; } 
    }

    public DateTime saveTime
    {
        get { return SaveTime; }
        set { SaveTime = value; }
    }

     public Dictionary<int, bool> completedLevels
    {
        get { return CompletedLevels; }
        set { CompletedLevels = value; }
    }

    // đánh dấu màn chơi là hoàn tất.
    public void MarkLevelAsCompleted(int levelId)
    {
        if (CompletedLevels.ContainsKey(levelId))
            CompletedLevels[levelId] = true;
        else
            CompletedLevels.Add(levelId, true);
    }
    // kiểm tra xem một màn chơi có hoàn tất hay chưa.
    public bool IsLevelCompleted(int levelId)
    {
        return CompletedLevels.ContainsKey(levelId) && CompletedLevels[levelId];
    }

    private void FixedUpdate() 
    {
        // Debug.Log("Gender: " + Gender);
        // Debug.Log("Player Name: " + PlayerName);
        // Debug.Log("Id: " + Id);
    }

    // Phương thức để sinh ID ngẫu nhiên
    public void GenerateRandomId()
    {   
        System.Random random = new System.Random();
        Id = random.Next(100000, 999999);
    }

    // Lưu thông tin người chơi
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        saveTime = DateTime.Now;
    }

    // Tải thông tin người chơi theo ID
   public void LoadPlayerById(int playerId)
    {
        PlayerData data = SaveSystem.LoadPlayer(playerId);
        if (data != null)
        {
            Id = data.Id;
            PlayerName = data.PlayerName;
            Gender = data.Gender;
            IdBV = data.IdBV;
            PositionPlayer = data.PositionPlayer;
            SaveTime = data.SaveTime;
            CompletedLevels = data.CompletedLevels ?? new Dictionary<int, bool>();

            transform.position = new Vector3(data.PositionPlayer[0], data.PositionPlayer[1], data.PositionPlayer[2]);
            Inventory = data.Inventory;
        }
        else
        {
            Debug.LogError("Không thể tải thông tin người chơi với ID: " + playerId);
        }
    }

    // Get all players
    public void DisplayAllPlayers()
    {
        List<PlayerData> allPlayers = SaveSystem.LoadAllPlayers();
        foreach (PlayerData playerData in allPlayers)
        {
            Debug.Log("ID: " + playerData.Id + ", Name: " + playerData.PlayerName + ", Gender: " + playerData.Gender + "Save Time; " + playerData.SaveTime);
        }
    }

   public void ResetPlayerData()
    {
        // Đặt lại ID và tên người chơi
        Id = 0;
        PlayerName = "";
        Gender = 0;

        IdBV = new int[0];
        PositionPlayer = new float[3] { -6.1f, -0.9f, 0f };  // Đặt về vị trí mặc định

        Inventory.Clear();
        

        CompletedLevels.Clear();

        SaveTime = DateTime.MinValue;

        transform.position = new Vector3(PositionPlayer[0], PositionPlayer[1], PositionPlayer[2]);

        Debug.Log("Player data has been reset.");
    }

    // Lấy toàn bộ dữ liệu trong Inventory
    public List<Item_Data> GetAllItems()
    {
        return Inventory;
    }

    // Thêm hoặc cập nhật Item theo IdItem
    public void AddOrUpdateItemById(int idItem, int quantity)
    {
        Item_Data item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
        {
            item.QuantityItem += quantity;  // Cộng dồn số lượng
        }
        else
        {
            Inventory.Add(new Item_Data(idItem, quantity));  // Thêm mới nếu chưa có
        }
    }

    // Thay đổi số lượng Item theo IdItem
    public void UpdateItemQuantityById(int idItem, int newQuantity)
    {
        Item_Data item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
        {
            item.QuantityItem = newQuantity;  // Cập nhật số lượng
        }
    }

    // Lấy dữ liệu Item theo IdItem
    public Item_Data GetItemById(int idItem)
    {
        return Inventory.FirstOrDefault(item => item.IdItem == idItem);
    }

    internal class Interact
    {
    }
}

