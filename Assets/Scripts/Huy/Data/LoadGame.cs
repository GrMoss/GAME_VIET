using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Để sử dụng TMP

public class LoadGame : MonoBehaviour
{
    public GameObject[] slotLoadData; // Mảng chứa các slot UI để hiển thị dữ liệu người chơi

    private void Start() 
    {
        LoadDataSave();
    }

    public void LoadDataSave()
    {
        List<PlayerData> allPlayers = SaveSystem.LoadAllPlayers();
        
        // Duyệt qua tất cả dữ liệu người chơi đã lưu
        for (int i = 0; i < allPlayers.Count; i++)
        {
            PlayerData playerData = allPlayers[i];

            // Chỉ kích hoạt slot nếu ID khác 0
            if (playerData.PlayerName != null && i < slotLoadData.Length)
            {
                // Kích hoạt slot UI
                slotLoadData[i].SetActive(true);

                // Lấy SlotData component từ đối tượng slotLoadData
                SlotData slotData = slotLoadData[i].GetComponent<SlotData>();

                // Gán thông tin vào SlotData
                slotData.Id = playerData.Id;
                slotData.PlayerName = playerData.PlayerName;
                slotData.Gender = playerData.Gender;
                slotData.SaveTime = playerData.SaveTime;

                // Cập nhật giao diện người dùng
                slotData.textId.text = "ID: " + slotData.Id;
                slotData.textPlayerName.text = "Name: " + slotData.PlayerName;
                slotData.textSaveTime.text = "Date: " + slotData.SaveTime.ToString("g"); // Định dạng thời gian
            }
            else if (i < slotLoadData.Length)
            {
                // Nếu ID = 0, ẩn slot để không hiển thị thông tin
                slotLoadData[i].SetActive(false);
            }
        }
    }
}