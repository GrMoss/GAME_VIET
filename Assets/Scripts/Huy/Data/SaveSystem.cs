// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
// using System.Runtime.Serialization;

// public class SaveSystem : MonoBehaviour
// {
//     public static SaveSystem Instance { get; private set; }
//          private void Awake()
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
//     }


//     // Lưu dữ liệu người chơi theo ID người chơi
//     public static void SavePlayer(Player player)
//     {
//         BinaryFormatter formatter = new BinaryFormatter();
//         string path = Application.persistentDataPath + "/playerData_" + player.id + ".dat"; // Tạo tệp duy nhất theo ID người chơi
        
//         using (FileStream fileStream = new FileStream(path, FileMode.Create))
//         {
//             PlayerData data = new PlayerData(player);
//             formatter.Serialize(fileStream, data);
//         }
//     }


//     // Tải dữ liệu người chơi theo ID người chơi
//     public static PlayerData LoadPlayer(int playerId)
//     {
//         string path = Application.persistentDataPath + "/playerData_" + playerId + ".dat"; // Tạo tệp duy nhất theo ID người chơi
//         if (File.Exists(path))
//         {
//             BinaryFormatter formatter = new BinaryFormatter();
//             using (FileStream fileStream = new FileStream(path, FileMode.Open))
//             {
//                 PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
//                 return data;
//             }
//         }
//         else
//         {
//             Debug.LogError("Tệp lưu không tồn tại tại " + path);
//             return null;
//         }
//     }

//     // Xóa dữ liệu người chơi theo ID
//     public static void DeletePlayer(int playerId)
//     {
//         string path = Application.persistentDataPath + "/playerData_" + playerId + ".dat"; // Tạo tệp duy nhất theo ID người chơi
//         if (File.Exists(path))
//         {
//             File.Delete(path);
//             Debug.Log("Xóa dữ liệu người chơi với ID: " + playerId);
//         }
//         else
//         {
//             Debug.LogError("Dữ liệu người chơi không tồn tại để xóa.");
//         }
//     }

  
//     public static List<PlayerData> LoadAllPlayers()
//     {
//         List<PlayerData> allPlayerData = new List<PlayerData>();
//         string[] files = Directory.GetFiles(Application.persistentDataPath, "playerData_*.dat");

//         foreach (string file in files)
//         {
//             try
//             {
//                 BinaryFormatter formatter = new BinaryFormatter();
//                 using (FileStream fileStream = new FileStream(file, FileMode.Open))
//                 {
//                     PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
//                     allPlayerData.Add(data);
//                 }
//             }
//             catch (SerializationException e)
//             {
//                 Debug.LogError("Không thể giải tuần tự tệp: " + file + " với lỗi: " + e.Message);
//                 File.Delete(file); // Xóa tệp lỗi
//             }
//             catch (IOException e)
//             {
//                 Debug.LogError("Lỗi I/O khi đọc tệp: " + file + " với lỗi: " + e.Message);
//             }
//         }

//         return allPlayerData;
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        string path = Application.persistentDataPath + "/playerData_" + player.id + ".json"; // Tạo tệp duy nhất theo ID người chơi
        PlayerData data = new PlayerData(player);
        string json = JsonUtility.ToJson(data, true); // Chuyển đổi dữ liệu thành chuỗi JSON

        File.WriteAllText(path, json); // Ghi dữ liệu JSON vào tệp
        Debug.Log("Player data saved to " + path);
    }

    // Tải dữ liệu người chơi theo ID người chơi
    public static PlayerData LoadPlayer(int playerId)
    {
        string path = Application.persistentDataPath + "/playerData_" + playerId + ".json"; // Tạo tệp duy nhất theo ID người chơi
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // Đọc dữ liệu JSON từ tệp
            PlayerData data = JsonUtility.FromJson<PlayerData>(json); // Chuyển đổi chuỗi JSON thành đối tượng PlayerData
            return data;
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
        string path = Application.persistentDataPath + "/playerData_" + playerId + ".json"; // Tạo tệp duy nhất theo ID người chơi
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

    // Tải tất cả dữ liệu người chơi
    public static List<PlayerData> LoadAllPlayers()
    {
        List<PlayerData> allPlayerData = new List<PlayerData>();
        string[] files = Directory.GetFiles(Application.persistentDataPath, "playerData_*.json");

        foreach (string file in files)
        {
            try
            {
                string json = File.ReadAllText(file); // Đọc dữ liệu JSON từ tệp
                PlayerData data = JsonUtility.FromJson<PlayerData>(json); // Chuyển đổi chuỗi JSON thành đối tượng PlayerData
                allPlayerData.Add(data);
            }
            catch (IOException e)
            {
                Debug.LogError("Lỗi I/O khi đọc tệp: " + file + " với lỗi: " + e.Message);
            }
        }

        return allPlayerData;
    }
}