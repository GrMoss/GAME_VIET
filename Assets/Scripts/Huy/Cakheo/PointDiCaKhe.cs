using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.SceneManagement;

public class PointDiCaKheo : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameComplete2 gameComplete2;
    public GameObject player;
    public GameObject sliderController;
    public TMP_Text textPoint;
    public static int Point;
    public int pointWinGame = 10;

    void Start()
    {
        Point = 0;
        SetActiveOJController(true);
        Player.Instance.IsLevelCompleted(1);
    }

    private void FixedUpdate() 
    {
        textPoint.text = Point.ToString();
        WinMiniGame();

    }

    private void WinMiniGame()
    {
        if(Point >= pointWinGame)
        {
            gameComplete2.isSuccess = true;
            gameOverPanel.SetActive(true);
            SetActiveOJController(false);
            Player.Instance.AddOrUpdateItemById(15,1);
            Player.Instance.MarkLevelAsCompleted(1);
        }
    }

    public void SetActiveOJController(bool setActive)
    {
        player.SetActive(setActive);
        sliderController.SetActive(setActive);
       
    }
}
