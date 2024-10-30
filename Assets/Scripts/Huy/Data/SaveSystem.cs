using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using System.Security.Cryptography;
using System.Text;

public class SaveSystem : MonoBehaviour
{
    private static readonly byte[] key = Encoding.UTF8.GetBytes("your32charSecretKeyHere012345678901"); // Đảm bảo có 32 ký tự
    private static readonly byte[] iv = Encoding.UTF8.GetBytes("your16charIVHere"); // Đảm bảo có 16 ký tự

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PlayerData data = new PlayerData(player);
            formatter.Serialize(memoryStream, data);

            byte[] encryptedData = Encrypt(memoryStream.ToArray());
            File.WriteAllBytes(Application.persistentDataPath + "/playerData", encryptedData);
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData";
        if (File.Exists(path))
        {
            byte[] encryptedData = File.ReadAllBytes(path);
            byte[] decryptedData = Decrypt(encryptedData);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(decryptedData))
            {
                PlayerData data = formatter.Deserialize(memoryStream) as PlayerData;
                return data;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    private static byte[] Encrypt(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }
    }

    private static byte[] Decrypt(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }
    }
}