using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class PiontDiCaKheo : MonoBehaviour
{

    public GameObject cardBV;
    public GameObject canvaPTC;

    public TMP_Text textPoint;
    public static int Point;
    public int piontWinGame = 10;

    void Start()
    {
        Point = 0;
        cardBV.SetActive(false);
        canvaPTC.SetActive(false);

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
            cardBV.SetActive(true);
            canvaPTC.SetActive(true);

        }
    }
}
