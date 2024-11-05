// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using Cinemachine;
// using System;


// public class Player : MonoBehaviour
// {
//     public static Player Instance { get; private set; }

//     private int Id;
//     private int Gender;
//     private string PlayerName;
//     private int[] IdBV;
//     private float[] PositionPlayer = new float[3]; // Khởi tạo mảng cho PositionPlayer
//     private List<Item_Data> Inventory = new List<Item_Data>();  // Danh sách Item_Data

//     private Dictionary<int, bool> CompletedLevels = new Dictionary<int, bool>();

//     private bool isDataLoaded = false;

//     private DateTime SaveTime;

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }

//         // Kiểm tra và khởi tạo vị trí nếu chưa được thiết lập
//         // if (PositionPlayer == null)
//         // {
//         //     PositionPlayer = new float[3] { -6.1f, -0.9f, 0f };
//         // }  
        
        
//     }

//     public int id
//     {
//         get { return Id; }
//         set { Id = value; } 
//     }
//     public string playerName
//     {
//         get { return PlayerName; }
//         set { PlayerName = value; } 
//     }

//     public int gender
//     {
//         get { return Gender; }
//         set { Gender = value; }
//     }

//     public int[] idBVArray
//     {
//         get { return IdBV; }
//         set { IdBV = value; }
//     }

//     public float[] positionPlayer
//     {
//         get { return PositionPlayer; }
//         set { PositionPlayer = value; }
//     }

//     public List<Item_Data> inventory
//     {
//         get { return Inventory; }
//         set { Inventory = value; } 
//     }

//     public DateTime saveTime
//     {
//         get { return SaveTime; }
//         set { SaveTime = value; }
//     }

//      public Dictionary<int, bool> completedLevels
//     {
//         get { return CompletedLevels; }
//         set { CompletedLevels = value; }
//     }

//     // đánh dấu màn chơi là hoàn tất.
//     public void MarkLevelAsCompleted(int levelId)
//     {
//         if (CompletedLevels.ContainsKey(levelId))
//             CompletedLevels[levelId] = true;
//         else
//             CompletedLevels.Add(levelId, true);
//     }
//     // kiểm tra xem một màn chơi có hoàn tất hay chưa.
//     public bool IsLevelCompleted(int levelId)
//     {
//         return CompletedLevels.ContainsKey(levelId) && CompletedLevels[levelId];
//     }

//     private void Start() 
//     {
//         // CheckPlayerIdAndUpdateLevels(Id);
//     }

//     private void FixedUpdate() 
//     {
//         // Debug.Log("Gender: " + Gender);
//         // Debug.Log("Player Name: " + PlayerName);
//         // Debug.Log("Id: " + Id);
//         // DebugLogPlayerLevels();
//     }

//     // Phương thức để sinh ID ngẫu nhiên
//     public void GenerateRandomId()
//     {   
//         System.Random random = new System.Random();
//         Id = random.Next(100000, 999999);
//     }

//     // Lưu thông tin người chơi
//     public void SavePlayer()
//     {
//         SaveSystem.SavePlayer(this);
//         saveTime = DateTime.Now;
//     }

//     // Tải thông tin người chơi theo ID
//     public void LoadPlayerById(int playerId)
//     {
//         PlayerData data = SaveSystem.LoadPlayer(playerId);
//         if (data != null)
//         {
//             Id = data.Id;
//             PlayerName = data.PlayerName;
//             Gender = data.Gender;
//             IdBV = data.IdBV;
//             PositionPlayer = data.PositionPlayer;
//             SaveTime = data.SaveTime;
//             Inventory = data.Inventory;

//             // Kiểm tra và thiết lập CompletedLevels nếu chưa có dữ liệu
//             if (data.CompletedLevels == null || data.CompletedLevels.Count == 0)
//             {
//                 CompletedLevels = new Dictionary<int, bool>();
//                 for (int levelId = 1; levelId <= 10; levelId++)
//                 {
//                     CompletedLevels[levelId] = false; // Đặt tất cả các level từ 1 đến 10 thành false
//                 }
//             }
//             else
//             {
//                 CompletedLevels = data.CompletedLevels; // Nếu có dữ liệu, cập nhật từ dữ liệu đã tải
//             }

//             // Cập nhật trạng thái tải dữ liệu thành công
//             isDataLoaded = true;
//             Debug.Log("Data loaded successfully for player ID: " + playerId);

//             // Ghi log thông tin các level
//             DebugLogPlayerLevels();
//         }
//         else
//         {
//             Debug.LogError("Không thể tải thông tin người chơi với ID: " + playerId);
//             // Đánh dấu rằng dữ liệu chưa được tải thành công
//             isDataLoaded = false;
//         }
//     }

//     public void CheckPlayerIdAndUpdateLevels(int playerId)
//     {
//         List<PlayerData> allPlayers = SaveSystem.LoadAllPlayers(); // Lấy tất cả người chơi từ hệ thống lưu trữ

//         // Kiểm tra xem playerId có trong danh sách người chơi không
//         bool playerExists = allPlayers.Any(player => player.Id == playerId);

//         if (!playerExists)
//         {
//             // Nếu không có trong danh sách, đặt tất cả level từ 1 đến 10 thành false
//             CompletedLevels.Clear();
//             for (int levelId = 1; levelId <= 10; levelId++)
//             {
//                 CompletedLevels[levelId] = false; // Đặt tất cả các level từ 1 đến 10 thành false
//             }
//             Debug.Log($"Player ID {playerId} not found. All levels set to false.");
//         }
//     }

//     // Phương thức mới để ghi log thông tin trạng thái hoàn thành của các level
//     private void DebugLogPlayerLevels()
//     {
//         foreach (var level in CompletedLevels)
//         {
//             Debug.Log($"Level ID: {level.Key}, Completed: {level.Value}");
//         }
//     }
//      public bool IsDataLoaded()
//     {
//         return isDataLoaded;
//     }

//     // Get all players
//     public void DisplayAllPlayers()
//     {
//         List<PlayerData> allPlayers = SaveSystem.LoadAllPlayers();
//         foreach (PlayerData playerData in allPlayers)
//         {
//             Debug.Log("ID: " + playerData.Id + ", Name: " + playerData.PlayerName + ", Gender: " + playerData.Gender + "Save Time; " + playerData.SaveTime);
//         }
//     }

//     public void ResetPlayerData()
//     {
//         // Đặt lại ID và tên người chơi
//         Id = 0;
//         PlayerName = "";
//         Gender = 0;

//         IdBV = new int[0];
//         PositionPlayer = new float[3] { -6.1f, -0.9f, 0f };  // Đặt về vị trí mặc định

//         Inventory.Clear();

//         // Đặt tất cả màn chơi từ 1 đến 10 thành false
//         CompletedLevels.Clear();
//         for (int levelId = 1; levelId <= 10; levelId++)
//         {
//             CompletedLevels[levelId] = false;
//         }

//         // SaveTime = DateTime.MinValue;

//         Debug.Log("Player data has been reset.");
//     }

//     // Lấy toàn bộ dữ liệu trong Inventory
//     public List<Item_Data> GetAllItems()
//     {
//         return Inventory;
//     }

//     // Thêm hoặc cập nhật Item theo IdItem
//     public void AddOrUpdateItemById(int idItem, int quantity)
//     {
//         Item_Data item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
//         if (item != null)
//         {
//             item.QuantityItem += quantity;  // Cộng dồn số lượng
//         }
//         else
//         {
//             Inventory.Add(new Item_Data(idItem, quantity));  // Thêm mới nếu chưa có
//         }
//     }

//     // Thay đổi số lượng Item theo IdItem
//     public void UpdateItemQuantityById(int idItem, int newQuantity)
//     {
//         Item_Data item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
//         if (item != null)
//         {
//             item.QuantityItem = newQuantity;  // Cập nhật số lượng
//         }
//     }

//     // Lấy dữ liệu Item theo IdItem
//     public Item_Data GetItemById(int idItem)
//     {
//         return Inventory.FirstOrDefault(item => item.IdItem == idItem);
//     }

//     internal class Interact
//     {
//     }
// }


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
    private int[] IdBV = new int[0];
    private float[] PositionPlayer = { -6.1f, -0.9f, 0f };
    private List<Item_Data> Inventory = new List<Item_Data>();
    private Dictionary<int, bool> CompletedLevels = Enumerable.Range(1, 10).ToDictionary(x => x, x => false);
    private bool isDataLoaded = false;
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
    }

    public int id { get => Id; set => Id = value; }
    public string playerName { get => PlayerName; set => PlayerName = value; }
    public int gender { get => Gender; set => Gender = value; }
    public int[] idBVArray { get => IdBV; set => IdBV = value; }
    public float[] positionPlayer { get => PositionPlayer; set => PositionPlayer = value; }
    public List<Item_Data> inventory { get => Inventory; set => Inventory = value; }
    public DateTime saveTime { get => SaveTime; set => SaveTime = value; }
    public Dictionary<int, bool> completedLevels { get => CompletedLevels; set => CompletedLevels = value; }

    // Mark level as completed
    public void MarkLevelAsCompleted(int levelId)
    {
        if (CompletedLevels.ContainsKey(levelId))
            CompletedLevels[levelId] = true;
    }

    // Check if a level is completed
    public bool IsLevelCompleted(int levelId) => CompletedLevels.ContainsKey(levelId) && CompletedLevels[levelId];

    // Generate random ID for the player
    public void GenerateRandomId() => Id = new System.Random().Next(100000, 999999);

    // Save player information
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        saveTime = DateTime.Now;
    }

    // Load player by ID
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
            Inventory = data.Inventory;
            CompletedLevels = data.CompletedLevels ?? new Dictionary<int, bool>(Enumerable.Range(1, 10).ToDictionary(x => x, x => false));

            isDataLoaded = true;
            Debug.Log("Data loaded successfully for player ID: " + playerId);
            DebugLogPlayerLevels();
        }
        else
        {
            Debug.LogError("Could not load player data for ID: " + playerId);
            isDataLoaded = false;
        }
    }

    // Check player ID and update levels
    public void CheckPlayerIdAndUpdateLevels(int playerId)
    {
        bool playerExists = SaveSystem.LoadAllPlayers().Any(player => player.Id == playerId);

        if (!playerExists)
        {
            CompletedLevels = Enumerable.Range(1, 10).ToDictionary(x => x, x => false);
            Debug.Log($"Player ID {playerId} not found. All levels set to false.");
            ResetPlayerData();
        }
    }

    // Log player level completion status
    private void DebugLogPlayerLevels()
    {
        foreach (var level in CompletedLevels)
            Debug.Log($"Level ID: {level.Key}, Completed: {level.Value}");
    }

    public bool IsDataLoaded() => isDataLoaded;

    // Display all players
    public void DisplayAllPlayers()
    {
        foreach (PlayerData playerData in SaveSystem.LoadAllPlayers())
            Debug.Log($"ID: {playerData.Id}, Name: {playerData.PlayerName}, Gender: {playerData.Gender}, Save Time: {playerData.SaveTime}");
    }

    // Reset player data
    public void ResetPlayerData()
    {
        Id = 0;
        PlayerName = "";
        Gender = 0;
        IdBV = new int[0];
        PositionPlayer = new float[3] { -6.1f, -0.9f, 0f };
        Inventory.Clear();
        CompletedLevels = Enumerable.Range(1, 10).ToDictionary(x => x, x => false);
        Debug.Log("Player data has been reset.");
    }

    public List<Item_Data> GetAllItems() => Inventory;

    public void AddOrUpdateItemById(int idItem, int quantity)
    {
        var item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
            item.QuantityItem += quantity;
        else
            Inventory.Add(new Item_Data(idItem, quantity));
    }

    public void UpdateItemQuantityById(int idItem, int newQuantity)
    {
        var item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
            item.QuantityItem = newQuantity;
    }

    public Item_Data GetItemById(int idItem) => Inventory.FirstOrDefault(item => item.IdItem == idItem);
}