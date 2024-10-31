using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SlotData : MonoBehaviour
{
    public GameObject[] avatarPlayer; 
    public TMP_Text textId; 
    public TMP_Text textPlayerName; 
    public TMP_Text textSaveTime; 
    public LoadGame loadGame;

    public int Id; 
    public string PlayerName; 
    public int Gender; 
    public DateTime SaveTime; 

    private void Awake() {
       
        for(int i = 0; i < avatarPlayer.Length; i++)
        {
            avatarPlayer[i].SetActive(false);
        }
    }

    private void Start() 
    {
        avatarPlayer[Gender].SetActive(true);
    }

    private void LoadPlayerById(int playerId)
    {
        PlayerData data = SaveSystem.LoadPlayer(playerId);
        if (data != null)
        {
            // Gán dữ liệu tải về cho instance người chơi
            Player.Instance.id = data.Id;
            Player.Instance.playerName = data.PlayerName;
            Player.Instance.gender = data.Gender;
            Player.Instance.idBVArray = data.IdBV;
            Player.Instance.positionPlayer = data.PositionPlayer;
            Player.Instance.saveTime = data.SaveTime; 

            // Đặt vị trí
            Player.Instance.transform.position = new Vector3(
                data.PositionPlayer[0], 
                data.PositionPlayer[1], 
                data.PositionPlayer[2]);

            // Tải kho đồ
            Player.Instance.inventory = data.Inventory;
        }
        else
        {
            Debug.LogError("Không thể tải thông tin người chơi với ID: " + playerId);
        }
    }

    public void LoadDataGame()
    {
        Debug.Log("IsWork");
        LoadPlayerById(Id); 
        StartCoroutine(Wait());
    
    }

    public void DeleteData()
    {
        loadGame.LoadDataSave();
        SaveSystem.DeletePlayer(Id);
        Debug.Log("Dữ liệu người chơi với ID " + Id + " đã được xóa.");
        gameObject.SetActive(false); 
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Home"); 
    }
}