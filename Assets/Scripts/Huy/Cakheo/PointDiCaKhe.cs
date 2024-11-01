using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.SceneManagement;

public class PiontDiCaKheo : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameComplete gameComplete;
    public GameObject player;
    public GameObject sliderController;
    public TMP_Text textPoint;
    public static int Point;
    public int piontWinGame = 10;

    void Start()
    {
        Point = 0;
       SetActiveOJController(true);
    }

    private void FixedUpdate() 
    {
        textPoint.text = Point.ToString();
        WinMiniGame();

    }

    private void WinMiniGame()
    {
        if(Point >= piontWinGame)
        {
            gameComplete.isSuccess = true;
            gameOverPanel.SetActive(true);
            SetActiveOJController(false);
        }
    }

    public void SetActiveOJController(bool setActive)
    {
        player.SetActive(setActive);
        sliderController.SetActive(setActive);
       
    }
}
