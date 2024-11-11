using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.SceneManagement;

public class NhayBaoBoPoint : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameComplete2 gameComplete2;
    public GameObject player;
    public TMP_Text textPoint;
    public static int Point;
    public int pointWinGame = 5;
    private bool hasWon = false;

    void Start()
    {
        Point = 0;
        SetActiveOJController(true);
        Player.Instance.IsLevelCompleted(3);
    }


    private void FixedUpdate()
    {
        textPoint.text = Point.ToString();
        WinMiniGame();
    }

    private void WinMiniGame()
    {
        if (!hasWon && Point >= pointWinGame)
        {
            Player.Instance.IsLevelCompleted(3);
            if(!Player.Instance.IsLevelCompleted(3))
            {
                Player.Instance.AddOrUpdateItemById(12, 1);
            }
            gameComplete2.isSuccess = true;
            gameOverPanel.SetActive(true);
            SetActiveOJController(false);
            Player.Instance.MarkLevelAsCompleted(3);
            hasWon = true;
        }
    }

    public void SetActiveOJController(bool setActive)
    {
        player.SetActive(setActive);

    }
}
