using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float time = 60;
    private float timer;
    public TextMeshProUGUI display;
    private void Awake()
    {
        timer = time;
    }
    private void FixedUpdate()
    {
        display.text = timer.ToString("00");
        timer -= Time.deltaTime;
        if (timer < 10f) display.color = Color.red;
    }
}
