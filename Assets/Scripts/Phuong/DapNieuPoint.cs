using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DapNieuPoint : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameComplete2 gameComplete2;
    //public GameObject player;
    //public GameObject sliderController;
    //public TMP_Text textPoint;
    public static int Point;
    public int pointWinGame = 10;
    public static bool hasWon = false;

    void Start()
    {
        Point = 0;
        hasWon = false;
        SetActiveOJController(true);
        //Player.Instance.IsLevelCompleted(1);
        // CheckLevelStatus(1);
    }

    // void CheckLevelStatus(int levelId)
    // {
    //     if (Player.Instance != null)
    //     {
    //         bool isCompleted = Player.Instance.IsLevelCompleted(levelId);

    //         if (isCompleted)
    //         {
    //             Debug.Log($"Level {levelId} đã hoàn tất.");
    //         }
    //         else
    //         {
    //             Debug.Log($"Level {levelId} chưa hoàn tất.");
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogError("Player instance chưa được khởi tạo.");
    //     }
    // }

    private void FixedUpdate()
    {
        //textPoint.text = Point.ToString();
        WinMiniGame();
    }

    private void WinMiniGame()
    {
        if (!hasWon && Point >= pointWinGame)
        {
            gameComplete2.isSuccess = true;
            gameOverPanel.SetActive(true);
            //SetActiveOJController(false);
            Player.Instance.AddOrUpdateItemById(15, 1);
            Player.Instance.MarkLevelAsCompleted(1);
            hasWon = true;
        }
    }

    public void SetActiveOJController(bool setActive)
    {
        //player.SetActive(setActive);
        //sliderController.SetActive(setActive);

    }
}
