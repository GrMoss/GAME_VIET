using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float time = 180;
    [HideInInspector] public float timer;
    public TextMeshProUGUI display;
    [HideInInspector] public bool isGameRunning;
    public CardData cardData;
    public GameComplete gameComplete;
    private void Awake()
    {
        timer = time;
        isGameRunning = true;
    }
    private void FixedUpdate()
    {
        if (isGameRunning)
        {
            display.text = timer.ToString("00");
            timer -= Time.deltaTime;
            if (timer < 10f) display.color = Color.red;
            else display.color = Color.white;
        }
        if (timer <= 0f)
        {
            cardData.StopGame();
            isGameRunning = false;
            timer = 0;
            gameComplete.isSuccess = false;
        }
    }
}
