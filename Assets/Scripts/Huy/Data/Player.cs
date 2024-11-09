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

    // Check if data is loaded
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

    // Get all player IDs
    public List<Item_Data> GetAllItems() => Inventory;

    // Add or update item by ID
    public void AddOrUpdateItemById(int idItem, int quantity)
    {
        var item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
            item.QuantityItem += quantity;
        else
            Inventory.Add(new Item_Data(idItem, quantity));
    }

    // Update item quantity by ID
    public void UpdateItemQuantityById(int idItem, int newQuantity)
    {
        var item = Inventory.FirstOrDefault(i => i.IdItem == idItem);
        if (item != null)
            item.QuantityItem = newQuantity;
    }

    public Item_Data GetItemById(int idItem) => Inventory.FirstOrDefault(item => item.IdItem == idItem);
}