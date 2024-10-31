using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
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


    // Lưu dữ liệu người chơi theo ID người chơi
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData_" + player.id + ".dat"; // Tạo tệp duy nhất theo ID người chơi
        
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            PlayerData data = new PlayerData(player);
            formatter.Serialize(fileStream, data);
        }
    }


    // Tải dữ liệu người chơi theo ID người chơi
    public static PlayerData LoadPlayer(int playerId)
    {
        string path = Application.persistentDataPath + "/playerData_" + playerId + ".dat"; // Tạo tệp duy nhất theo ID người chơi
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
                return data;
            }
        }
        else
        {
            Debug.LogError("Tệp lưu không tồn tại tại " + path);
            return null;
        }
    }

    // Xóa dữ liệu người chơi theo ID
    public static void DeletePlayer(int playerId)
    {
        string path = Application.persistentDataPath + "/playerData_" + playerId + ".dat"; // Tạo tệp duy nhất theo ID người chơi
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Xóa dữ liệu người chơi với ID: " + playerId);
        }
        else
        {
            Debug.LogError("Dữ liệu người chơi không tồn tại để xóa.");
        }
    }

    // Tải thông tin của tất cả người chơi
    public static List<PlayerData> LoadAllPlayers()
    {
        List<PlayerData> allPlayerData = new List<PlayerData>();
        string[] files = Directory.GetFiles(Application.persistentDataPath, "playerData_*.dat");

        foreach (string file in files)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(file, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
                allPlayerData.Add(data);
            }
        }

        return allPlayerData;
    }
}